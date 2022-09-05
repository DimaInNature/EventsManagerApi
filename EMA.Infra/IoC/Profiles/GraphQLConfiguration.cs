namespace EMA.Infra.IoC.Profiles;

public static class GraphQLConfiguration
{
    public static void AddGraphQLApi(
       this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        services.AddGraphQLServer()
            .AddQueryType<EventGraphQLQuery>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
    }
}