namespace Integrador.Common.Scheduling.Models
{
    /// <summary>
    /// Como o dia de execução mensal é determinado. FirstBusinessDay não corresponde a um
    /// gatilho nativo do Windows Task Scheduler (que não sabe o que são feriados em Portugal) -
    /// por isso é calculado por TaskSchedulerHelper e reagendado a cada arranque da aplicação
    /// (ver TaskSchedulerHelper.ConfigurarTarefaMensalDiaUtil).
    /// </summary>
    public enum MonthlyScheduleModeEnum
    {
        FixedDay = 0,
        FirstBusinessDay = 1
    }
}
