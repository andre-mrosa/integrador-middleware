using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Integrador.Common;
using Integrador.Common.Logging;
using Integrador.Common.Scheduling;
using Integrador.Common.Settings;
using Integrador.Source;
using Integrador.Integration;
using Integrador.Integration.Contracts;
using Integrador.UI.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Integrador.UI
{
    internal static class Program
    {
        private const string AutoArgument = "AUTO";

        private static Mutex? _mutex;

        [STAThread]
        static void Main(string[] args)
        {
            if (!EnsureSingleInstance())
                return;

            using IHost host = BuildHost(args);
            var services = host.Services;
            var logger = services.GetRequiredService<IIntegrationLogger>();

            bool isAutoMode = args.Contains(AutoArgument, StringComparer.OrdinalIgnoreCase);

            try
            {
                ApplicationConfiguration.Initialize();
                AppTheme.Initialize();

                // Avança agendamentos "1º dia útil do mês" (também quando é a própria tarefa a arrancar)
                RevalidateSchedules(services, logger);

                if (isAutoMode)
                {
                    RunAuto(services, logger);
                    return;
                }

                SplashScreenManager.ShowForm(typeof(SplashScreen1));
                ValidateStartup(services, isAutoMode: false);
                SplashScreenManager.CloseForm(false);

                Application.Run(services.GetRequiredService<MainForm>());
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);

                logger.CriticalAsync("Program", "Ocorreu um erro crítico no integrador", ex).GetAwaiter().GetResult();

                if (!isAutoMode)
                    XtraMessageBox.Show($"Ocorreu um erro crítico no integrador.\n{ex.Message}\n\nConsulte as logs para mais informações.", AppInfo.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IHost BuildHost(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services
                .AddCommon()
                .AddSourceModule()
                .AddIntegrationModule()
                .AddUi();

            return builder.Build();
        }

        /// <summary>
        /// Execução via Agendador do Windows. Sem UI, tudo para logs.
        /// </summary>
        private static void RunAuto(IServiceProvider services, IIntegrationLogger logger)
        {
            if (!ValidateStartup(services, isAutoMode: true))
                return;

            try
            {
                services.GetRequiredService<IIntegrationRunner>().RunAsync(IntegrationTrigger.Auto).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                logger.ErrorAsync("Program", "Ocorreu um erro na integração automática", ex).GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// Confirma que existe configuração. Em modo manual deixa sempre abrir a aplicação para se poder configurar.
        /// </summary>
        private static bool ValidateStartup(IServiceProvider services, bool isAutoMode)
        {
            var settings = services.GetRequiredService<ISettingsService>();
            var logger = services.GetRequiredService<IIntegrationLogger>();

            if (!settings.Exists)
            {
                ShowError("Não existe ficheiro de configurações. Configure o integrador no menu Configurações.", isAutoMode, logger);
                return false;
            }

            return true;
        }

        private static void RevalidateSchedules(IServiceProvider services, IIntegrationLogger logger)
        {
            try
            {
                foreach (string erro in services.GetRequiredService<ISchedulerService>().RevalidateAll(Application.ExecutablePath))
                    logger.WarningAsync("Program", $"Não foi possível revalidar o agendamento {erro}").GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                logger.ErrorAsync("Program", "Erro ao revalidar agendamentos.", ex).GetAwaiter().GetResult();
            }
        }

        private static void ShowError(string message, bool isAutoMode, IIntegrationLogger logger)
        {
            if (isAutoMode)
            {
                logger.ErrorAsync("Program", $"AUTO: {message}").GetAwaiter().GetResult();
                return;
            }

            SplashScreenManager.CloseForm(false);
            XtraMessageBox.Show(message, AppInfo.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static bool EnsureSingleInstance()
        {
            _mutex = new Mutex(true, AppInfo.Name, out bool isFirstInstance);
            return isFirstInstance;
        }
    }
}
