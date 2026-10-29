using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Integrador.Common.Logging;
using Integrador.UI.Configuration;
using Integrador.UI.Forms;

namespace Integrador.UI.UserControls
{
    public partial class LogsUserControl : XtraUserControl, IRefreshable
    {
        private readonly ILogQueryService _logQuery;
        private bool _filtersReady;

        public LogsUserControl(ILogQueryService logQuery)
        {
            _logQuery = logQuery;
            InitializeComponent();
            AppTheme.ApplyListStyle(gvLogs);
        }

        private async void LogsUserControl_Load(object sender, EventArgs e)
        {
            LoadLevelComboBox();

            deStartDate.EditValue = DateTime.Today.AddDays(-7);
            deEndDate.EditValue = DateTime.Today;

            _filtersReady = true;
            await LoadLogsAsync();
        }

        /// <summary>Nível e datas aplicam-se logo que mudam. Ignorado enquanto o Load preenche os valores iniciais.</summary>
        private async void Filter_Changed(object? sender, EventArgs e)
        {
            if (_filtersReady)
                await LoadLogsAsync();
        }

        public Task RefreshDataAsync() => LoadLogsAsync();

        /// <summary>Pesquisa em todas as colunas das logs já carregadas (sem voltar a ler os ficheiros).</summary>
        private void beSearch_EditValueChanged(object sender, EventArgs e) => gvLogs.ApplyFindFilter(beSearch.Text);

        private void gvLogs_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column != colLevel || e.CellValue is not LogLevel level)
                return;

            e.Appearance.ForeColor = level switch
            {
                LogLevel.ERROR or LogLevel.CRITICAL => DXSkinColors.FillColors.Danger,
                LogLevel.WARNING => DXSkinColors.FillColors.Warning,
                LogLevel.INFO => DXSkinColors.FillColors.Primary,
                _ => DXSkinColors.ForeColors.DisabledText
            };
        }

        private void gvLogs_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colLevel && e.Value is LogLevel level)
                e.DisplayText = $"●  {LevelText(level)}";
        }

        private static string LevelText(LogLevel level) => level switch
        {
            LogLevel.ALL => "Todos",
            LogLevel.INFO => "Info",
            LogLevel.WARNING => "Aviso",
            LogLevel.ERROR => "Erro",
            LogLevel.DEBUG => "Debug",
            LogLevel.CRITICAL => "Crítico",
            _ => level.ToString()
        };

        private void gvLogs_DoubleClick(object sender, EventArgs e)
        {
            if (sender is not GridView view)
                return;

            // Só abre ao clicar numa linha (não no cabeçalho nem no painel de pesquisa)
            var hit = view.CalcHitInfo(view.GridControl.PointToClient(MousePosition));
            if (!hit.InRow || view.GetRow(hit.RowHandle) is not IntegratorLog log)
                return;

            using var form = new LogDetailForm(log);
            form.ShowDialog(FindForm());
        }

        private void LoadLevelComboBox()
        {
            cbeLogType.Properties.Items.Clear();

            foreach (LogLevel level in Enum.GetValues<LogLevel>())
                cbeLogType.Properties.Items.Add(new ImageComboBoxItem(LevelText(level), level, -1));

            cbeLogType.SelectedIndex = 0;
        }

        private async Task LoadLogsAsync()
        {
            using IOverlaySplashScreenHandle overlay = SplashScreenManager.ShowOverlayForm(this);
            try
            {
                LogLevel level = (LogLevel)((cbeLogType.SelectedItem as ImageComboBoxItem)?.Value ?? LogLevel.ALL);

                var logs = await _logQuery.GetFilteredAsync(level, deStartDate.EditValue as DateTime?, deEndDate.EditValue as DateTime?);

                integratorLogsBindingSource.DataSource = logs;
                gvLogs.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Erro ao filtrar logs: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
