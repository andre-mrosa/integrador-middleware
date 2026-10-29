using System.IO;
using System.Text.Json;

namespace Integrador.UI.Configuration
{
    public class SkinSettings
    {
        public string? SkinName { get; set; }
        public string? PaletteName { get; set; }

        #region SETTINGS FILE

        private static readonly string _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppInfo.StorageFolder);
        private static readonly string _filePath = Path.Combine(_folderPath, "skin.json");

        public static void SaveSkin(SkinSettings settings)
        {
            try
            {
                if (!Directory.Exists(_folderPath))
                    Directory.CreateDirectory(_folderPath);

                JsonSerializerOptions options = new() { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(settings, options);

                File.WriteAllText(_filePath, jsonString);
            }
            catch { /* Silencioso para não interromper o fecho da app */ }
        }

        public static SkinSettings GetSkinSettings()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new SkinSettings();

                string jsonString = File.ReadAllText(_filePath);

                return JsonSerializer.Deserialize<SkinSettings>(jsonString) ?? new SkinSettings();
            }
            catch
            {
                return new SkinSettings();
            }
        }

        #endregion
    }
}
