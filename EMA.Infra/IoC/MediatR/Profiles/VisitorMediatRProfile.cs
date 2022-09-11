namespace EMA.Infra.IoC.MediatR.Profiles;

public static class VisitorMediatRProfile
{
    public static void AddVisitorMediatRProfile(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVisitorCommand>();
        services.AddScoped<IRequestHandler<CreateVisitorCommand, bool>, CreateVisitorCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVisitorCommand>();
        services.AddScoped<IRequestHandler<UpdateVisitorCommand, bool>, UpdateVisitorCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVisitorCommand>();
        services.AddScoped<IRequestHandler<DeleteVisitorCommand, bool>, DeleteVisitorCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<VisitorEntity?>, GetVisitorQuery>();
        services.AddScoped<IRequestHandler<GetVisitorQuery, VisitorEntity?>, GetVisitorQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VisitorEntity>>, GetVisitorsListQuery>();
        services.AddScoped<IRequestHandler<GetVisitorsListQuery, IEnumerable<VisitorEntity>>, GetVisitorsListQueryHandler>();

        #endregion
    }
}