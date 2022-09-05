namespace EMA.Infra.IoC.Profiles;

public static class RepositoriesConfiguration
{
    public static void AddRepositoriesConfiguration(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        services.AddScoped(
            serviceType: typeof(IGenericRepository<>),
            implementationType: typeof(GenericRepository<>));
    }
}