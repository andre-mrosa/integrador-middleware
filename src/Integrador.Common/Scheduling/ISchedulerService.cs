using Integrador.Common.Scheduling.Models;

namespace Integrador.Common.Scheduling;

/// <summary>
/// Agendamentos no Agendador de Tarefas do Windows (componente .Net Schedulers portado).
/// Requer permissões de administrador para criar/remover tarefas.
/// </summary>
public interface ISchedulerService
{
    List<ScheduleModel> GetAll();

    /// <summary>Regista a tarefa e guarda o agendamento. Se a gravação falhar remove a tarefa.</summary>
    void Add(ScheduleModel schedule, string exePath);

    void Remove(ScheduleModel schedule);

    /// <summary>
    /// Avança os agendamentos "1º dia útil do mês". Chamar em cada arranque (incluindo AUTO).
    /// Devolve os erros encontrados, um por agendamento.
    /// </summary>
    List<string> RevalidateAll(string exePath);

    /// <summary>Próxima execução entre todas as tarefas ativas (lida do Agendador do Windows).</summary>
    DateTime? GetNextRunTime();
}
