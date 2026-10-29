using Integrador.Source.Auth;
using Integrador.Source.Contracts;
using Integrador.Source.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Integrador.Source;

public static class SourceModule
{
    public static IServiceCollection AddSourceModule(this IServiceCollection services)
    {
        services.AddSingleton<SourceTokenProvider>();
        services.AddTransient<SourceAuthHandler>();

        services.AddHttpClient(SourceTokenProvider.HttpClientName, c => c.Timeout = TimeSpan.FromSeconds(30));

        services.AddHttpClient<ISourceApiClient, SourceApiClient>(c =>
            {
                c.Timeout = TimeSpan.FromMinutes(2);
                c.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            })
            .AddHttpMessageHandler<SourceAuthHandler>();

        return services;
    }
}
