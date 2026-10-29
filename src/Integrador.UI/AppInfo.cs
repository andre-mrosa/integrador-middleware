namespace Integrador.UI;

/// <summary>
/// Identidade da aplicação. Único sítio a alterar nos nomes visíveis quando se cria um integrador novo a partir do template.
/// </summary>
internal static class AppInfo
{
    // TODO: nome da aplicação (ex: Integrador CRM-ERP). Também usado no mutex de instância única
    public const string Name = "Integrador";

    /// <summary>Pasta em %LocalAppData% para preferências do utilizador (tema).</summary>
    // TODO: pasta própria por integrador (ex: IntegradorCrmErp)
    public const string StorageFolder = "Integrador";

    // TODO: nome do sistema de origem (ex: CRM)
    public const string SourceName = "Sistema A";
    // TODO: nome do sistema de destino (ex: ERP)
    public const string TargetName = "Sistema B";

    /// <summary>Cor de destaque (botões principais, seleção no menu, links).</summary>
    // TODO: cor da marca do cliente, se fizer sentido
    public static readonly Color AccentColor = Color.FromArgb(0x0F, 0x6C, 0xBD);

    public static string Version => Application.ProductVersion.Split('+')[0];
}
