namespace EMA.Infra.IoC.Profiles;

public static class ServicesConfiguration
{
    public static void AddServiceConfiguration(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        services.AddScoped<IEventsService, EventsService>();

        services.AddScoped<IEventStatesService, EventStatesService>();

        services.AddScoped<IVisitorContactsService, VisitorContactsService>();

        services.AddScoped<IVisitorCredentialsService, VisitorCredentialsService>();

        services.AddScoped<IVisitorGendersService, VisitorGendersService>();

        services.AddScoped<IVisitorsService, VisitorsService>();
    }
}