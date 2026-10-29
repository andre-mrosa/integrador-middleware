using Integrador.UI.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace Integrador.UI;

public static class UiModule
{
    public static IServiceCollection AddUi(this IServiceCollection services)
    {
        services.AddTransient<MainForm>();
        services.AddTransient<HomeUserControl>();
        services.AddTransient<ConfigurationsUserControl>();
        services.AddTransient<LogsUserControl>();
        services.AddTransient<SchedulerUserControl>();
        return services;
    }
}
