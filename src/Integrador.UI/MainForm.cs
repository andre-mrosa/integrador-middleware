using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Integrador.Common.Logging;
using Integrador.Integration.Contracts;
using Integrador.UI.Configuration;
using Integrador.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace Integrador.UI
{
    public partial class MainForm : FluentDesignForm
    {
        private readonly IServiceProvider _services;
        private readonly IIntegrationRunner _integrationRunner;
        private readonly IIntegrationLogger _logger;

        /// <summary>Páginas já abertas. Cada página é criada uma vez e mantém o estado ao navegar.</summary>
        private readonly Dictionary<Type, XtraUserControl> _pages = [];

        public MainForm(IServiceProvider services, IIntegrationRunner integrationRunner, IIntegrationLogger logger)
        {
            _services = services;
            _integrationRunner = integrationRunner;
            _logger = logger;

            InitializeComponent();

            Text = $"{AppInfo.Name}  v{AppInfo.Version}";
            UpdateThemeButton();
            RestoreWindowState();
        }

        private void MainForm_Shown(object? sender, EventArgs e)
        {
            // Reabre a última página usada
            switch (UiPreferences.Current.LastPage)
            {
                case nameof(LogsUserControl): ShowPage<LogsUserControl>(aceLogs); break;
                case nameof(SchedulerUserControl): ShowPage<SchedulerUserControl>(aceScheduler); break;
                case nameof(ConfigurationsUserControl): ShowPage<ConfigurationsUserControl>(aceConfigs); break;
                default: ShowPage<HomeUserControl>(aceHome); break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_integrationRunner.IsRunning &&
                XtraMessageBox.Show("Está uma integração em curso. Fechar agora pode deixar dados a meio.\nTem a certeza que pretende sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            SaveWindowState();
        }

        /// <summary>
        /// Repõe tamanho, posição e menu como ficaram na última sessão. Se o ecrã onde estava já não existir, abre centrado.
        /// </summary>
        private void RestoreWindowState()
        {
            var prefs = UiPreferences.Current;

            if (prefs.WindowBounds is [int x, int y, int width, int height])
            {
                var bounds = new Rectangle(x, y, width, height);
                if (Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(bounds)))
                {
                    StartPosition = FormStartPosition.Manual;
                    Bounds = bounds;
                }
            }

            if (prefs.WindowMaximized)
                WindowState = FormWindowState.Maximized;

            if (prefs.MenuMinimized)
                accordionControl1.OptionsMinimizing.State = AccordionControlState.Minimized;
        }

        private void SaveWindowState()
        {
            var prefs = UiPreferences.Current;

            Rectangle bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            prefs.WindowBounds = [bounds.X, bounds.Y, bounds.Width, bounds.Height];
            prefs.WindowMaximized = WindowState == FormWindowState.Maximized;
            prefs.MenuMinimized = accordionControl1.OptionsMinimizing.State == AccordionControlState.Minimized;

            UiPreferences.Save();
        }

        private void aceHome_Click(object sender, EventArgs e) => ShowPage<HomeUserControl>(aceHome);

        private void aceLogs_Click(object sender, EventArgs e) => ShowPage<LogsUserControl>(aceLogs);

        private void aceScheduler_Click(object sender, EventArgs e) => ShowPage<SchedulerUserControl>(aceScheduler);

        private void aceConfigs_Click(object sender, EventArgs e) => ShowPage<ConfigurationsUserControl>(aceConfigs);

        private void bbiTheme_ItemClick(object sender, ItemClickEventArgs e)
        {
            AppTheme.ToggleDark();
            UpdateThemeButton();
        }

        /// <summary>
        /// Atualiza todas as páginas abertas que dependem do resultado da integração.
        /// </summary>
        private async Task OnIntegrationFinishedAsync()
        {
            foreach (var page in _pages.Values)
            {
                if (page is IRefreshable refreshable)
                    await refreshable.RefreshDataAsync();
            }
        }

        private void UpdateThemeButton()
        {
            bool dark = AppTheme.IsDark;
            bbiTheme.Caption = dark ? "Tema claro" : "Tema escuro";
            bbiTheme.ImageOptions.SvgImage = svgImages[dark ? "light" : "dark"];
        }

        /// <summary>
        /// Mostra a página (resolvida pelo DI na primeira vez) e marca o item no menu lateral.
        /// </summary>
        private void ShowPage<T>(AccordionControlElement element) where T : XtraUserControl
        {
            try
            {
                if (!_pages.TryGetValue(typeof(T), out XtraUserControl? page))
                {
                    page = CreatePage<T>();
                    page.Dock = DockStyle.Fill;
                    fluentDesignFormContainer1.Controls.Add(page);
                    _pages[typeof(T)] = page;
                }

                page.BringToFront();
                accordionControl1.SelectedElement = element;
                UiPreferences.Current.LastPage = typeof(T).Name;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir {element.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private T CreatePage<T>() where T : XtraUserControl
        {
            T control = _services.GetRequiredService<T>();

            // Execuções lançadas a partir do Início também atualizam as outras páginas
            if (control is HomeUserControl home)
                home.IntegrationFinished += async (_, _) => await OnIntegrationFinishedAsync();

            return control;
        }
    }
}
