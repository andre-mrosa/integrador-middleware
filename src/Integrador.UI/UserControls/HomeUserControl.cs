using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Integrador.Common.Logging;
using Integrador.Common.Scheduling;
using Integrador.Common.Settings;
using Integrador.Integration.Contracts;
using Integrador.UI.Configuration;

namespace Integrador.UI.UserControls
{
    /// <summary>
    /// Ecrã inicial. Estado das ligações, última/próxima execução e histórico.
    /// </summary>
    public partial class HomeUserControl : XtraUserControl, IRefreshable
    {
        private readonly ISettingsService _settings;
        private readonly ISchedulerService _scheduler;
        private readonly IIntegrationRunHistory _history;
        private readonly IIntegrationRunner _runner;
        private readonly IIntegrationLogger _logger;

        /// <summary>Disparado depois de uma execução lançada a partir deste ecrã (com ou sem erro).</summary>
        public event EventHandler? IntegrationFinished;

        public HomeUserControl(ISettingsService settings, ISchedulerService scheduler, IIntegrationRunHistory history, IIntegrationRunner runner, IIntegrationLogger logger)
        {
            _settings = settings;
            _scheduler = scheduler;
            _history = history;
            _runner = runner;
            _logger = logger;

            InitializeComponent();
            AppTheme.ApplyListStyle(gvRuns);
        }

        private async void HomeUserControl_Load(object sender, EventArgs e) => await RefreshDataAsync();

        private async void sbRefresh_Click(object sender, EventArgs e) => await RefreshDataAsync();

        private async void sbRunNow_Click(object sender, EventArgs e)
        {
            sbRunNow.Enabled = false;
            using IOverlaySplashScreenHandle overlay = SplashScreenManager.ShowOverlayForm(this);
            try
            {
                await _runner.RunAsync(IntegrationTrigger.Manual);
                overlay.Close();
                XtraMessageBox.Show("Integração concluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(HomeUserControl), "Ocorreu um erro na integração.", ex);
                overlay.Close();
                XtraMessageBox.Show($"Ocorreu um erro na integração.\n{ex.Message}\n\nPara mais informações, verifique as logs.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sbRunNow.Enabled = true;
                IntegrationFinished?.Invoke(this, EventArgs.Empty);
            }
        }

        public async Task RefreshDataAsync()
        {
            var settings = _settings.Get();
            var runs = await _history.GetRecentAsync();
            var last = runs.FirstOrDefault();
            DateTime? next = await Task.Run(_scheduler.GetNextRunTime);

            hccStatus.DataContext = new HomeStatus
            {
                SourceLabel = $"Origem · {AppInfo.SourceName}",
                SourceValue = settings.IsSourceConfigured ? "Configurada" : "Por configurar",

                TargetLabel = $"Destino · {AppInfo.TargetName}",
                TargetValue = settings.IsTargetConfigured ? "Configurado" : "Por configurar",

                LastRunValue = last == null ? "Sem execuções" : last.StartedAt.ToString("dd/MM/yyyy HH:mm"),
                LastRunHint = last == null ? "Ainda não foi executada" : last.Status == IntegrationRunStatus.Success ? "Concluída com sucesso" : "Terminou com erro",

                NextRunValue = next.HasValue ? next.Value.ToString("dd/MM/yyyy HH:mm") : "Sem agendamento",
                NextRunHint = next.HasValue ? "Agendador do Windows" : "Configure em Agendamento"
            };

            SetTone("sourceValue", "value", settings.IsSourceConfigured ? "ok" : "warn");
            SetTone("targetValue", "value", settings.IsTargetConfigured ? "ok" : "warn");
            SetTone("lastRunHint", "hint", last == null ? null : last.Status == IntegrationRunStatus.Success ? "ok" : "error");

            gcRuns.DataSource = runs;
        }

        /// <summary>Cor de um elemento dos cartões. tone: ok, warn, error ou null (cor normal).</summary>
        private void SetTone(string elementId, string baseClass, string? tone)
        {
            if (hccStatus.FindElementById(elementId) is { } element)
                element.ClassName = tone == null ? baseClass : $"{baseClass} {tone}";
        }

        private void gvRuns_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colDuration && e.Value is TimeSpan duration)
                e.DisplayText = duration.ToString(@"hh\:mm\:ss");
            else if (e.Column == colTrigger && e.Value is IntegrationTrigger trigger)
                e.DisplayText = trigger == IntegrationTrigger.Auto ? "Agendada" : "Manual";
            else if (e.Column == colStatus && e.Value is IntegrationRunStatus status)
                e.DisplayText = status == IntegrationRunStatus.Success ? "●  Sucesso" : "●  Erro";
        }

        private void gvRuns_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colStatus || sender is not GridView view || view.GetRow(e.RowHandle) is not IntegrationRun run)
                return;

            e.Appearance.ForeColor = run.Status == IntegrationRunStatus.Success ? DXSkinColors.FillColors.Success : DXSkinColors.FillColors.Danger;
        }

        /// <summary>Dados dos cartões de estado (template HTML em hccStatus).</summary>
        private sealed class HomeStatus
        {
            public string SourceLabel { get; init; } = "";
            public string SourceValue { get; init; } = "";
            public string TargetLabel { get; init; } = "";
            public string TargetValue { get; init; } = "";
            public string LastRunValue { get; init; } = "";
            public string LastRunHint { get; init; } = "";
            public string NextRunValue { get; init; } = "";
            public string NextRunHint { get; init; } = "";
        }
    }
}
