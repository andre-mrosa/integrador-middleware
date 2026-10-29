using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using Integrador.Common.Logging;
using Integrador.Common.Settings;
using Integrador.Source.Contracts;
using System.Net.Http;

namespace Integrador.UI.UserControls
{
    public partial class ConfigurationsUserControl : XtraUserControl
    {
        private readonly ISettingsService _settingsService;
        private readonly ISourceApiClient _source;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIntegrationLogger _logger;

        public ConfigurationsUserControl(ISettingsService settingsService, ISourceApiClient source, IHttpClientFactory httpClientFactory, IIntegrationLogger logger)
        {
            _settingsService = settingsService;
            _source = source;
            _httpClientFactory = httpClientFactory;
            _logger = logger;

            InitializeComponent();
        }

        private void ConfigurationsUserControl_Load(object sender, EventArgs e)
        {
            var config = _settingsService.Get();

            teSourceUrl.Text = config.SourceUrl;
            teSourceApiKey.Text = config.SourceApiKey;
            teSourceUser.Text = config.SourceUser;
            teSourcePassword.Text = config.SourcePassword;

            teTargetUrl.Text = config.TargetUrl;
            teTargetUser.Text = config.TargetUser;
            teTargetPassword.Text = config.TargetPassword;
        }

        private async void sbSave_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Tem a certeza que pretende guardar as configurações?", "Questão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                Save();
                XtraMessageBox.Show("Configurações guardadas com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(ConfigurationsUserControl), "Ocorreu um erro ao guardar as configurações.", ex);
                XtraMessageBox.Show($"Ocorreu um erro ao guardar as configurações.\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void sbTestSource_Click(object sender, EventArgs e)
        {
            using IOverlaySplashScreenHandle overlay = SplashScreenManager.ShowOverlayForm(this);
            try
            {
                // Testa o que está no ecrã, guardado ou não
                await _source.TestConnectionAsync(ReadForm(new IntegratorSettings()));
                overlay.Close();
                XtraMessageBox.Show($"Ligação a {AppInfo.SourceName} efetuada com sucesso.", AppInfo.SourceName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(ConfigurationsUserControl), $"Teste de ligação a {AppInfo.SourceName} falhou.", ex);
                overlay.Close();
                string message = ex is SourceApiException source ? source.Detail : ex.GetBaseException().Message;
                XtraMessageBox.Show($"Não foi possível ligar a {AppInfo.SourceName}.\n{message}", AppInfo.SourceName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Por agora só valida que o URL responde.
        /// TODO: login real quando existir o módulo da API de destino
        /// </summary>
        private async void sbTestTarget_Click(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(teTargetUrl.Text, UriKind.Absolute, out Uri? url) || (url.Scheme != Uri.UriSchemeHttp && url.Scheme != Uri.UriSchemeHttps))
            {
                XtraMessageBox.Show("Indique um URL válido (http ou https).", AppInfo.TargetName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using IOverlaySplashScreenHandle overlay = SplashScreenManager.ShowOverlayForm(this);
            try
            {
                using var http = _httpClientFactory.CreateClient();
                http.Timeout = TimeSpan.FromSeconds(15);

                using var response = await http.GetAsync(url);
                overlay.Close();

                XtraMessageBox.Show($"O servidor de {AppInfo.TargetName} respondeu ({(int)response.StatusCode} {response.ReasonPhrase}).\nO login será validado quando a integração com o destino estiver implementada.",
                    AppInfo.TargetName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                await _logger.ErrorAsync(nameof(ConfigurationsUserControl), $"Teste de ligação a {AppInfo.TargetName} falhou ({url}).", ex);
                overlay.Close();
                XtraMessageBox.Show($"O servidor de {AppInfo.TargetName} não respondeu.\n{ex.GetBaseException().Message}", AppInfo.TargetName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Save() => _settingsService.Save(ReadForm(_settingsService.Get()));

        /// <summary>
        /// Copia os campos do ecrã para <paramref name="target"/>. Para guardar (sobre as configurações atuais) ou só para testar (objeto novo).
        /// </summary>
        private IntegratorSettings ReadForm(IntegratorSettings target)
        {
            target.SourceUrl = teSourceUrl.Text.Trim();
            target.SourceApiKey = teSourceApiKey.Text.Trim();
            target.SourceUser = teSourceUser.Text.Trim();
            target.SourcePassword = teSourcePassword.Text;

            target.TargetUrl = teTargetUrl.Text.Trim();
            target.TargetUser = teTargetUser.Text.Trim();
            target.TargetPassword = teTargetPassword.Text;

            return target;
        }

        private void teSourcePassword_ButtonClick(object sender, ButtonPressedEventArgs e) => TogglePasswordVisibility(sender, e);

        private void teTargetPassword_ButtonClick(object sender, ButtonPressedEventArgs e) => TogglePasswordVisibility(sender, e);

        private void TogglePasswordVisibility(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag?.ToString()?.ToUpper() != "PASSWORD" || sender is not TextEdit editor)
                return;

            editor.Properties.UseSystemPasswordChar = !editor.Properties.UseSystemPasswordChar;

            e.Button.ImageOptions.SvgImage = editor.Properties.UseSystemPasswordChar
                ? svgImageCollection1["security_visibility"]
                : svgImageCollection1["security_visibilityoff"];
        }
    }
}
