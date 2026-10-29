#nullable disable
// Portado de .Net Schedulers (C:\Mine\.Net Schedulers, UserControlScheduler). Manter alinhado com o original.
using Integrador.Common.Scheduling.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Integrador.Common.Scheduling.Models
{
    public class ScheduleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Frequência escolhida (Mapeia perfeitamente para o SelectedIndex do RadioGroup)
        public ScheduleFrequencyEnum Frequency { get; set; }

        // Hora de Execução
        public TimeSpan RunTime { get; set; }

        // Dias da Semana (Para o formato Semanal)
        public List<string> SelectedDaysOfWeek { get; set; } = new List<string>();

        // Dia do Mês (Para o formato Mensal, quando MonthlyMode == FixedDay)
        public int DayOfMonth { get; set; }

        // Para o formato Mensal: dia fixo do mês, ou 1º dia útil (+ OffsetDays)
        public MonthlyScheduleModeEnum MonthlyMode { get; set; } = MonthlyScheduleModeEnum.FixedDay;

        // Dias corridos a somar ao 1º dia útil do mês (só relevante quando MonthlyMode == FirstBusinessDay)
        public int OffsetDays { get; set; }

        public bool IsEnabled { get; set; }

        public string Argument { get; set; }

        private string _taskName;

        /// <summary>
        /// Nome da tarefa no Task Scheduler. Guardado no JSON para que agendamentos antigos
        /// (ScheduledTask_{Id}) continuem a apontar para a tarefa certa. Novos agendamentos usam o
        /// nome do executável anfitrião, para se identificarem no Agendador de Tarefas.
        /// </summary>
        public string TaskName
        {
            get
            {
                if (string.IsNullOrEmpty(_taskName))
                    _taskName = $"{NomeAplicacao()}_{Id}";
                return _taskName;
            }
            set { _taskName = value; }
        }

        private static string NomeAplicacao()
        {
            string nome = Assembly.GetEntryAssembly()?.GetName().Name ?? "ScheduledTask";
            char[] invalidos = Path.GetInvalidFileNameChars();
            return new string(nome.Select(c => invalidos.Contains(c) ? '_' : c).ToArray());
        }
    }
}
