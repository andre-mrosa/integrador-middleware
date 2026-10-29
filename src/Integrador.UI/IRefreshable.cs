namespace Integrador.UI;

/// <summary>
/// Separadores que mostram dados que mudam depois de uma integração. O MainForm atualiza-os no fim de cada execução.
/// </summary>
public interface IRefreshable
{
    Task RefreshDataAsync();
}
