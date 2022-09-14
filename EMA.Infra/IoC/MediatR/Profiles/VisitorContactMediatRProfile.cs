namespace EMA.Infra.IoC.MediatR.Profiles;

public static class VisitorContactMediatRProfile
{
    public static void AddVisitorContactMediatRProfile(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVisitorContactCommand>();
        services.AddScoped<IRequestHandler<CreateVisitorContactCommand, bool>, CreateVisitorContactCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVisitorContactCommand>();
        services.AddScoped<IRequestHandler<UpdateVisitorContactCommand, bool>, UpdateVisitorContactCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVisitorContactCommand>();
        services.AddScoped<IRequestHandler<DeleteVisitorContactCommand, bool>, DeleteVisitorContactCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<VisitorContactEntity?>, GetVisitorContactQuery>();
        services.AddScoped<IRequestHandler<GetVisitorContactQuery, VisitorContactEntity?>, GetVisitorContactQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VisitorContactEntity>>, GetVisitorContactsListQuery>();
        services.AddScoped<IRequestHandler<GetVisitorContactsListQuery, IEnumerable<VisitorContactEntity>>, GetVisitorContactsListQueryHandler>();

        #endregion
    }
}