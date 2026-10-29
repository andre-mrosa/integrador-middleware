#nullable disable
// Portado de .Net Schedulers (C:\Mine\.Net Schedulers, UserControlScheduler). Manter alinhado com o original.
using Integrador.Common.Scheduling.Models;
using Microsoft.Win32.TaskScheduler;
using Nager.Date;
using System;
using System.IO;
using System.Linq;

namespace Integrador.Common.Scheduling
{
    /// <summary>
    /// Agenda execuções periódicas de um executável através do Windows Task Scheduler.
    /// </summary>
    internal static class TaskSchedulerHelper
    {
        /// <summary>
        /// Configura a tarefa agendada adaptando-se a qualquer frequência escolhida.
        /// A tarefa fica registada mesmo quando ativo = false, mas desativada no Task Scheduler.
        /// </summary>
        public static void ConfigurarTarefaDinamica(
            string taskName,
            string exePath,
            ScheduleFrequencyEnum frequencia,
            TimeSpan horaExecucao,
            DaysOfTheWeek diasSemana = 0,
            int[] diasMes = null,
            string argumentos = null,
            bool ativo = true)
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Execução agendada.";

                // 1. Criar a variável base para o gatilho
                Trigger trigger;

                // 2. Construir o gatilho consoante a frequência pedida
                switch (frequencia)
                {
                    case ScheduleFrequencyEnum.Daily:
                        trigger = new DailyTrigger { DaysInterval = 1 };
                        break;

                    case ScheduleFrequencyEnum.Weekly:
                        if (diasSemana == 0) throw new ArgumentException("Tem de selecionar pelo menos um dia da semana.");
                        trigger = new WeeklyTrigger { DaysOfWeek = diasSemana, WeeksInterval = 1 };
                        break;

                    case ScheduleFrequencyEnum.Monthly:
                        if (diasMes == null || diasMes.Length == 0) throw new ArgumentException("Tem de selecionar pelo menos um dia do mês.");
                        trigger = new MonthlyTrigger { DaysOfMonth = diasMes };
                        break;

                    default:
                        throw new InvalidOperationException("Frequência desconhecida.");
                }

                // 3. Configurar a hora de arranque (comum a todos)
                trigger.StartBoundary = DateTime.Today + horaExecucao;
                td.Triggers.Add(trigger);

                // 4. Configurar a Ação. Pasta de trabalho = pasta do executável (sem isto corre em System32
                //    e qualquer caminho relativo da aplicação falha)
                td.Actions.Add(new ExecAction(exePath, argumentos, Path.GetDirectoryName(exePath)));
                td.Settings.StartWhenAvailable = true;
                td.Settings.Enabled = ativo;

                // 5. APAGAR a tarefa antiga primeiro (garante que não há conflitos de atualização)
                ts.RootFolder.DeleteTask(taskName, exceptionOnNotExists: false);

                // 6. Registar a nova tarefa limpa
                ts.RootFolder.RegisterTaskDefinition(taskName, td);
            }
        }

        /// <summary>
        /// Remove a tarefa do Agendador de Tarefas do Windows.
        /// </summary>
        public static void RemoverTarefa(string taskName)
        {
            using (TaskService ts = new TaskService())
            {
                // Apaga a tarefa e ignora caso ela não exista (exceptionOnNotExists: false)
                ts.RootFolder.DeleteTask(taskName, exceptionOnNotExists: false);
            }
        }

        /// <summary>
        /// Calcula o 1º dia útil (não fim de semana, não feriado em Portugal) do mês indicado,
        /// somando depois offsetDiasCorridos dias de calendário.
        /// </summary>
        public static DateTime CalcularPrimeiroDiaUtil(int ano, int mes, int offsetDiasCorridos)
        {
            DateTime data = new DateTime(ano, mes, 1);
            while (DateSystem.IsWeekend(data, CountryCode.PT) || DateSystem.IsPublicHoliday(data, CountryCode.PT))
            {
                data = data.AddDays(1);
            }

            return data.AddDays(offsetDiasCorridos);
        }

        /// <summary>
        /// Próxima execução "1º dia útil do mês (+ offset) à hora indicada" a partir de agora.
        /// Usa o mês atual se a data ainda não passou, senão o mês seguinte.
        /// </summary>
        public static DateTime CalcularProximaExecucaoDiaUtil(int offsetDiasCorridos, TimeSpan horaExecucao, DateTime agora)
        {
            DateTime esteMes = CalcularPrimeiroDiaUtil(agora.Year, agora.Month, offsetDiasCorridos) + horaExecucao;
            if (esteMes > agora)
                return esteMes;

            DateTime proximoMes = new DateTime(agora.Year, agora.Month, 1).AddMonths(1);
            return CalcularPrimeiroDiaUtil(proximoMes.Year, proximoMes.Month, offsetDiasCorridos) + horaExecucao;
        }

        public static string DescricaoDiaUtil(int offsetDias)
        {
            return "Execução agendada - 1º dia útil do mês"
                + (offsetDias != 0 ? $" + {offsetDias} dia(s)" : "") + ".";
        }

        /// <summary>
        /// Configura (ou revalida) uma tarefa mensal cujo dia de execução é o 1º dia útil do mês
        /// (+ offsetDias dias corridos). Sem correspondência direta num MonthlyTrigger do Task
        /// Scheduler (que não conhece feriados portugueses), por isso usa-se um TimeTrigger para a
        /// próxima ocorrência calculada. Tem de ser chamado em cada arranque da aplicação
        /// (ver ISchedulerService.RevalidateAll) para a tarefa avançar mês a mês.
        /// Só recria a tarefa quando a data ou o estado configurados não são os corretos.
        /// </summary>
        public static void ConfigurarTarefaMensalDiaUtil(
            string taskName,
            string exePath,
            int offsetDias,
            TimeSpan horaExecucao,
            string argumentos,
            string descricao,
            bool ativo = true)
        {
            DateTime dataAlvo = CalcularProximaExecucaoDiaUtil(offsetDias, horaExecucao, DateTime.Now);

            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task existingTask = ts.GetTask(taskName);
                if (existingTask != null)
                {
                    bool dataCorreta = existingTask.Definition.Triggers.Any(t => t.StartBoundary == dataAlvo);

                    if (dataCorreta && existingTask.Definition.Settings.Enabled == ativo) return;

                    ts.RootFolder.DeleteTask(taskName, exceptionOnNotExists: false);
                }

                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = descricao;
                td.Triggers.Add(new TimeTrigger { StartBoundary = dataAlvo });
                td.Actions.Add(new ExecAction(exePath, argumentos, Path.GetDirectoryName(exePath)));
                td.Settings.StartWhenAvailable = true;
                td.Settings.Enabled = ativo;

                ts.RootFolder.RegisterTaskDefinition(taskName, td);
            }
        }

    }
}
