using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Integrador.Common.Settings;

/// <summary>
/// Configurações guardadas em JSON encriptado (AES) no ficheiro config.config ao lado do executável.
/// </summary>
internal sealed class EncryptedSettingsService : ISettingsService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "config.config");

    // TODO: chave própria por integrador (16 caracteres cada). Mover para DPAPI se o config não precisar de ser copiado entre máquinas
    private static readonly byte[] _aesKey = Encoding.UTF8.GetBytes("IntegradorKey_01");
    private static readonly byte[] _aesIV = Encoding.UTF8.GetBytes("IntegradorIV__01");

    private readonly Lock _lock = new();
    private IntegratorSettings? _cache;

    public event EventHandler? Changed;

    public bool Exists => File.Exists(_filePath);

    public IntegratorSettings Get()
    {
        lock (_lock)
        {
            return _cache ??= Load();
        }
    }

    public void Save(IntegratorSettings settings)
    {
        lock (_lock)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllBytes(_filePath, Encrypt(json));
            _cache = settings;
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }

    private static IntegratorSettings Load()
    {
        if (!File.Exists(_filePath))
            return new IntegratorSettings();

        string json = Decrypt(File.ReadAllBytes(_filePath));
        return JsonSerializer.Deserialize<IntegratorSettings>(json) ?? new IntegratorSettings();
    }

    private static byte[] Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = _aesKey;
        aes.IV = _aesIV;

        using MemoryStream ms = new();
        using (CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (StreamWriter sw = new(cs))
        {
            sw.Write(plainText);
        }
        return ms.ToArray();
    }

    private static string Decrypt(byte[] cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = _aesKey;
        aes.IV = _aesIV;

        using MemoryStream ms = new(cipherText);
        using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader sr = new(cs);
        return sr.ReadToEnd();
    }
}
