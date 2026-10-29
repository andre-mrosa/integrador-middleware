using Integrador.Common.Logging;
using Integrador.Common.Scheduling;
using Integrador.Common.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Common;

public static class CommonModule
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsService, EncryptedSettingsService>();

        services.AddSingleton<FileIntegrationLogger>();
        services.AddSingleton<IIntegrationLogger>(sp => sp.GetRequiredService<FileIntegrationLogger>());
        services.AddSingleton<ILogQueryService>(sp => sp.GetRequiredService<FileIntegrationLogger>());

        services.AddSingleton<ISchedulerService, WindowsSchedulerService>();

        return services;
    }
}
