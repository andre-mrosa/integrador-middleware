using Integrador.Common.Scheduling.Models;
using Integrador.Common.Settings;
using Microsoft.Win32.TaskScheduler;

namespace Integrador.Common.Scheduling;

internal sealed class WindowsSchedulerService(ISettingsService settingsService) : ISchedulerService
{
    // Texto dos itens do ccbeDaysOfWeek -> dia do Task Scheduler
    private static readonly Dictionary<string, DaysOfTheWeek> _days = new()
    {
        ["Segunda-feira"] = DaysOfTheWeek.Monday,
        ["Terça-feira"] = DaysOfTheWeek.Tuesday,
        ["Quarta-feira"] = DaysOfTheWeek.Wednesday,
        ["Quinta-feira"] = DaysOfTheWeek.Thursday,
        ["Sexta-feira"] = DaysOfTheWeek.Friday,
        ["Sábado"] = DaysOfTheWeek.Saturday,
        ["Domingo"] = DaysOfTheWeek.Sunday
    };

    public List<ScheduleModel> GetAll() => [.. settingsService.Get().Schedules];

    public void Add(ScheduleModel schedule, string exePath)
    {
        Register(schedule, exePath);

        try
        {
            var settings = settingsService.Get();
            settings.Schedules.Add(schedule);
            settingsService.Save(settings);
        }
        catch
        {
            // Rollback: sem isto a tarefa ficava órfã no Windows
            try { TaskSchedulerHelper.RemoverTarefa(schedule.TaskName); } catch { /* sem permissões */ }
            settingsService.Get().Schedules.RemoveAll(s => s.Id == schedule.Id);
            throw;
        }
    }

    public void Remove(ScheduleModel schedule)
    {
        TaskSchedulerHelper.RemoverTarefa(schedule.TaskName);

        var settings = settingsService.Get();
        settings.Schedules.RemoveAll(s => s.Id == schedule.Id);
        settingsService.Save(settings);
    }

    public List<string> RevalidateAll(string exePath)
    {
        List<string> erros = [];

        foreach (var schedule in GetAll().Where(s => s.Frequency == ScheduleFrequencyEnum.Monthly && s.MonthlyMode == MonthlyScheduleModeEnum.FirstBusinessDay))
        {
            try
            {
                TaskSchedulerHelper.ConfigurarTarefaMensalDiaUtil(schedule.TaskName, exePath, schedule.OffsetDays, schedule.RunTime,
                    schedule.Argument, TaskSchedulerHelper.DescricaoDiaUtil(schedule.OffsetDays), schedule.IsEnabled);
            }
            catch (Exception ex)
            {
                erros.Add($"{schedule.TaskName}: {ex.Message}");
            }
        }

        return erros;
    }

    public DateTime? GetNextRunTime()
    {
        try
        {
            using TaskService ts = new();

            var next = GetAll()
                .Where(s => s.IsEnabled)
                .Select(s => ts.GetTask(s.TaskName))
                .Where(t => t is { Enabled: true })
                .Select(t => t!.NextRunTime)
                .Where(d => d > DateTime.Now)
                .DefaultIfEmpty(DateTime.MinValue)
                .Min();

            return next == DateTime.MinValue ? null : next;
        }
        catch
        {
            return null; // Sem acesso ao Agendador não é motivo para falhar a UI
        }
    }

    private static void Register(ScheduleModel s, string exePath)
    {
        switch (s.Frequency)
        {
            case ScheduleFrequencyEnum.Daily:
                TaskSchedulerHelper.ConfigurarTarefaDinamica(s.TaskName, exePath, ScheduleFrequencyEnum.Daily, s.RunTime, argumentos: s.Argument, ativo: s.IsEnabled);
                break;

            case ScheduleFrequencyEnum.Weekly:
                DaysOfTheWeek dias = 0;
                foreach (var day in s.SelectedDaysOfWeek)
                    if (_days.TryGetValue(day.Trim(), out var d)) dias |= d;

                TaskSchedulerHelper.ConfigurarTarefaDinamica(s.TaskName, exePath, ScheduleFrequencyEnum.Weekly, s.RunTime, diasSemana: dias, argumentos: s.Argument, ativo: s.IsEnabled);
                break;

            case ScheduleFrequencyEnum.Monthly when s.MonthlyMode == MonthlyScheduleModeEnum.FirstBusinessDay:
                TaskSchedulerHelper.ConfigurarTarefaMensalDiaUtil(s.TaskName, exePath, s.OffsetDays, s.RunTime, s.Argument,
                    TaskSchedulerHelper.DescricaoDiaUtil(s.OffsetDays), s.IsEnabled);
                break;

            case ScheduleFrequencyEnum.Monthly:
                TaskSchedulerHelper.ConfigurarTarefaDinamica(s.TaskName, exePath, ScheduleFrequencyEnum.Monthly, s.RunTime, diasMes: [s.DayOfMonth], argumentos: s.Argument, ativo: s.IsEnabled);
                break;

            default:
                throw new InvalidOperationException("Frequência desconhecida.");
        }
    }
}
