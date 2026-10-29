using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Integrador.Common.Logging;
using System.Text;
using System.Text.Json;

namespace Integrador.UI.Forms
{
    public partial class LogDetailForm : XtraForm
    {
        private static readonly JsonSerializerOptions _indented = new() { WriteIndented = true };

        public LogDetailForm(IntegratorLog log)
        {
            InitializeComponent();

            lblHeader.Text = $"{log.Level}  ·  {log.Source}  ·  {log.LoggedAt:dd/MM/yyyy HH:mm:ss}";
            lblHeader.Appearance.ForeColor = log.Level switch
            {
                LogLevel.ERROR or LogLevel.CRITICAL => DXSkinColors.ForeColors.Critical,
                LogLevel.WARNING => DXSkinColors.ForeColors.Warning,
                _ => DXSkinColors.ForeColors.ControlText
            };

            meMessage.Text = log.Message;
            meException.Text = log.Exception;
            mePayload.Text = FormatJson(log.Payload);

            lciException.Visibility = string.IsNullOrWhiteSpace(log.Exception) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lciPayload.Visibility = string.IsNullOrWhiteSpace(log.Payload) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        /// <summary>Payloads da API vêm numa linha, indentados ficam legíveis.</summary>
        private static string? FormatJson(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            try
            {
                using var doc = JsonDocument.Parse(value);
                return JsonSerializer.Serialize(doc.RootElement, _indented);
            }
            catch (JsonException)
            {
                return value;
            }
        }

        private void sbCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine(lblHeader.Text);
            sb.AppendLine();
            sb.AppendLine(meMessage.Text);

            if (!string.IsNullOrWhiteSpace(meException.Text))
                sb.AppendLine().AppendLine("Exceção:").AppendLine(meException.Text);

            if (!string.IsNullOrWhiteSpace(mePayload.Text))
                sb.AppendLine().AppendLine("Payload:").AppendLine(mePayload.Text);

            Clipboard.SetText(sb.ToString());
        }
    }
}
