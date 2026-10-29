using System.IO;
using System.Text.Json;

namespace Integrador.UI.Configuration
{
    /// <summary>
    /// Estado da interface do utilizador (tema, janela, página e menu), para abrir como foi deixada.
    /// Guardado em %LocalAppData%\{AppInfo.StorageFolder}\preferences.json.
    /// </summary>
    public class UiPreferences
    {
        public bool DarkTheme { get; set; }

        /// <summary>Posição e tamanho da janela no estado normal (não maximizado). Null na primeira execução.</summary>
        public int[]? WindowBounds { get; set; }
        public bool WindowMaximized { get; set; }

        /// <summary>Nome do tipo da última página aberta (ex: LogsUserControl).</summary>
        public string? LastPage { get; set; }
        public bool MenuMinimized { get; set; }

        #region SETTINGS FILE

        private static readonly string _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppInfo.StorageFolder);
        private static readonly string _filePath = Path.Combine(_folderPath, "preferences.json");
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        private static UiPreferences? _current;

        /// <summary>Lido uma vez do ficheiro. Alterações ficam em memória até Save().</summary>
        public static UiPreferences Current => _current ??= Load();

        public static void Save()
        {
            try
            {
                Directory.CreateDirectory(_folderPath);
                File.WriteAllText(_filePath, JsonSerializer.Serialize(Current, _options));
            }
            catch { /* Silencioso para não interromper o fecho da app */ }
        }

        private static UiPreferences Load()
        {
            try
            {
                return File.Exists(_filePath)
                    ? JsonSerializer.Deserialize<UiPreferences>(File.ReadAllText(_filePath)) ?? new UiPreferences()
                    : new UiPreferences();
            }
            catch
            {
                return new UiPreferences();
            }
        }

        #endregion
    }
}
