namespace EMA.Infra.IoC.MediatR.Profiles;

public static class EventStateMediatRProfile
{
    public static void AddEventStateMediatRProfile(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateEventStateCommand>();
        services.AddScoped<IRequestHandler<CreateEventStateCommand, bool>, CreateEventStateCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateEventStateCommand>();
        services.AddScoped<IRequestHandler<UpdateEventStateCommand, bool>, UpdateEventStateCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteEventStateCommand>();
        services.AddScoped<IRequestHandler<DeleteEventStateCommand, bool>, DeleteEventStateCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<EventStateEntity?>, GetEventStateQuery>();
        services.AddScoped<IRequestHandler<GetEventStateQuery, EventStateEntity?>, GetEventStateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<EventStateEntity>>, GetEventStatesListQuery>();
        services.AddScoped<IRequestHandler<GetEventStatesListQuery, IEnumerable<EventStateEntity>>, GetEventStatesListQueryHandler>();

        #endregion
    }
}