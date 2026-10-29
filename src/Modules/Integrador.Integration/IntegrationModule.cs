using Integrador.Integration.Application;
using Integrador.Integration.Contracts;
using Integrador.Integration.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Integration;

public static class IntegrationModule
{
    public static IServiceCollection AddIntegrationModule(this IServiceCollection services)
    {
        services.AddSingleton<FileIntegrationRunHistory>();
        services.AddSingleton<IIntegrationRunHistory>(sp => sp.GetRequiredService<FileIntegrationRunHistory>());
        services.AddTransient<IIntegrationRunner, IntegrationRunner>();
        return services;
    }
}
