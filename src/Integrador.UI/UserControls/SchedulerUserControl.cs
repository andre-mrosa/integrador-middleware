using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using Integrador.Common.Logging;
using Integrador.Common.Scheduling;
using Integrador.Common.Scheduling.Models;
using Integrador.UI.Configuration;
using System.ComponentModel;

namespace Integrador.UI.UserControls
{
    /// <summary>
    /// Agendador portado de .Net Schedulers (UserControlScheduler). Designer igual ao original,
    /// lógica e persistência via ISchedulerService.
    /// </summary>
    public partial class SchedulerUserControl : XtraUserControl
    {
        private readonly ISchedulerService _scheduler;
        private readonly IIntegrationLogger _logger;
        private BindingList<ScheduleModel> _schedulesList = new();

        public SchedulerUserControl(ISchedulerService scheduler, IIntegrationLogger logger)
        {
            _scheduler = scheduler;
            _logger = logger;

            InitializeComponent();
            AppTheme.ApplyListStyle(gvSchedules);
        }

        private void SchedulerUserControl_Load(object sender, EventArgs e)
        {
            using IOverlaySplashScreenHandle overlay = SplashScreenManager.ShowOverlayForm(this);

            _schedulesList = new BindingList<ScheduleModel>(_scheduler.GetAll());
            gcSchedules.DataSource = _schedulesList;

            rgFrequency.SelectedIndex = 0;
            tseHora.TimeSpan = TimeSpan.Zero;
            tsEnabled.IsOn = true;
            seDayOfMonth.Value = 1;
            ceDiaUtilMensal.Checked = false;
            seOffsetDias.Value = 0;
            ccbeDaysOfWeek.SetEditValue(string.Empty);
            cbeArgument.SelectedIndex = 0;

            AtualizarVisibilidadeControlos();
        }

        private void GvSchedules_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SelectedDaysOfWeek" && e.Value is List<string> list)
                e.DisplayText = string.Join(", ", list);
        }

        private async void RepoBtnRemove_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gvSchedules.GetFocusedRow() is not ScheduleModel schedule)
                return;

            if (XtraMessageBox.Show("Remover agendamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _scheduler.Remove(schedule);
                _schedulesList.Remove(schedule);
            }
            catch (UnauthorizedAccessException)
            {
                XtraMessageBox.Show("Execute a aplicação como Administrador para remover a tarefa do sistema.", "Sem Permissões", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(SchedulerUserControl), "Erro ao remover agendamento.", ex);
                XtraMessageBox.Show($"Ocorreu um erro ao remover a tarefa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rgFrequency_SelectedIndexChanged(object sender, EventArgs e) => AtualizarVisibilidadeControlos();

        private void ceDiaUtilMensal_CheckedChanged(object sender, EventArgs e) => AtualizarVisibilidadeControlos();

        private async void sbAdd_Click(object sender, EventArgs e)
        {
            tseHora.DoValidate();

            var schedule = new ScheduleModel
            {
                Frequency = (ScheduleFrequencyEnum)rgFrequency.SelectedIndex,
                RunTime = tseHora.TimeSpan,
                DayOfMonth = Convert.ToInt32(seDayOfMonth.Value),
                MonthlyMode = ceDiaUtilMensal.Checked ? MonthlyScheduleModeEnum.FirstBusinessDay : MonthlyScheduleModeEnum.FixedDay,
                OffsetDays = Convert.ToInt32(seOffsetDias.Value),
                SelectedDaysOfWeek = ccbeDaysOfWeek.EditValue?.ToString()?
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList() ?? [],
                IsEnabled = tsEnabled.IsOn,
                Argument = cbeArgument.Text
            };

            if (schedule.Frequency == ScheduleFrequencyEnum.Weekly && schedule.SelectedDaysOfWeek.Count == 0)
            {
                XtraMessageBox.Show("Selecione pelo menos um dia da semana.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (schedule.Frequency == ScheduleFrequencyEnum.Monthly && schedule.MonthlyMode == MonthlyScheduleModeEnum.FixedDay && schedule.DayOfMonth > 28
                && XtraMessageBox.Show($"Os meses sem dia {schedule.DayOfMonth} não terão execução.\nPretende continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _scheduler.Add(schedule, Application.ExecutablePath);
                _schedulesList.Add(schedule);

                string estado = schedule.IsEnabled ? "ativada" : "desativada";
                XtraMessageBox.Show($"Configuração guardada com sucesso!\nA sincronização automática encontra-se {estado}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                XtraMessageBox.Show("Execute a aplicação como Administrador para configurar a tarefa.", "Sem Permissões", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(SchedulerUserControl), "Erro ao guardar agendamento.", ex);
                XtraMessageBox.Show($"Ocorreu um erro ao guardar o agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reposiciona explicitamente os itens da 2ª linha (ver comentário no original .Net Schedulers):
        /// o colapso automático da LayoutControl não liberta o espaço de forma fiável com 4 itens nesta linha.
        /// </summary>
        private void AtualizarVisibilidadeControlos()
        {
            layoutControl1.BeginUpdate();
            lcgControl.BestFit();
            try
            {
                lciDayOfWeek.Visibility = LayoutVisibility.Never;
                lciDayOfMonth.Visibility = LayoutVisibility.Never;
                lciDiaUtilMensal.Visibility = LayoutVisibility.Never;
                lciOffsetDias.Visibility = LayoutVisibility.Never;

                switch ((ScheduleFrequencyEnum)rgFrequency.SelectedIndex)
                {
                    case ScheduleFrequencyEnum.Weekly:
                        lciDayOfWeek.Visibility = LayoutVisibility.Always;
                        break;

                    case ScheduleFrequencyEnum.Monthly:
                        // 1º dia útil (checkbox) + dia fixo OU dias a somar, no mesmo slot
                        lciDiaUtilMensal.Visibility = LayoutVisibility.Always;
                        seDayOfMonth.Size = seOffsetDias.Size;

                        if (ceDiaUtilMensal.Checked)
                            lciOffsetDias.Visibility = LayoutVisibility.Always;
                        else
                            lciDayOfMonth.Visibility = LayoutVisibility.Always;
                        break;
                }
            }
            finally
            {
                layoutControl1.EndUpdate();
            }
        }
    }
}
