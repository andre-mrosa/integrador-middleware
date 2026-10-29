namespace Integrador.Common.Settings;

public interface ISettingsService
{
    /// <summary>Existe ficheiro de configuração.</summary>
    bool Exists { get; }

    /// <summary>Configuração atual (em cache). Devolve valores por defeito se não existir ficheiro.</summary>
    IntegratorSettings Get();

    void Save(IntegratorSettings settings);

    /// <summary>Disparado após guardar. Usado para invalidar caches (ex: token da API de origem).</summary>
    event EventHandler? Changed;
}
