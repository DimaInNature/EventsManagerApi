namespace EMA.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        services.AddRepositoriesConfiguration();

        services.AddServiceConfiguration();

        services.AddMediatRConfiguration();
    }
}