using Integrador.Common.Scheduling.Models;
using System.Text.Json.Serialization;

namespace Integrador.Common.Settings;

public sealed class IntegratorSettings
{
    #region ORIGEM

    // TODO: campos de ligação da API de origem (ex: uma API que usa URL + API key + email/password)
    public string SourceUrl { get; set; } = "";
    public string? SourceApiKey { get; set; }
    public string? SourceUser { get; set; }
    public string? SourcePassword { get; set; }

    #endregion

    #region DESTINO

    // TODO: campos de ligação da API de destino (ex: um ERP web que usa URL + utilizador/password)
    public string? TargetUrl { get; set; }
    public string? TargetUser { get; set; }
    public string? TargetPassword { get; set; }

    #endregion

    [JsonIgnore]
    public bool IsSourceConfigured => !string.IsNullOrWhiteSpace(SourceUrl) && !string.IsNullOrWhiteSpace(SourceApiKey)
                                      && !string.IsNullOrWhiteSpace(SourceUser) && !string.IsNullOrWhiteSpace(SourcePassword);

    [JsonIgnore]
    public bool IsTargetConfigured => !string.IsNullOrWhiteSpace(TargetUrl) && !string.IsNullOrWhiteSpace(TargetUser)
                                      && !string.IsNullOrWhiteSpace(TargetPassword);

    public List<ScheduleModel> Schedules { get; set; } = [];
}
