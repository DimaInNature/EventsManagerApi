namespace EMA.Infra.IoC.MediatR.Profiles;

public static class EventMediatRProfile
{
    public static void AddEventMediatRProfile(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(
            argument: services,
            paramName: nameof(services));

        #region Commands

        services.AddScoped<IRequest<bool>, CreateEventCommand>();
        services.AddScoped<IRequestHandler<CreateEventCommand, bool>, CreateEventCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateEventCommand>();
        services.AddScoped<IRequestHandler<UpdateEventCommand, bool>, UpdateEventCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteEventCommand>();
        services.AddScoped<IRequestHandler<DeleteEventCommand, bool>, DeleteEventCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteEventsListCommand>();
        services.AddScoped<IRequestHandler<DeleteEventsListCommand, bool>, DeleteEventsListCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<EventEntity?>, GetEventQuery>();
        services.AddScoped<IRequestHandler<GetEventQuery, EventEntity?>, GetEventQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<EventEntity>>, GetEventsListQuery>();
        services.AddScoped<IRequestHandler<GetEventsListQuery, IEnumerable<EventEntity>>, GetEventsListQueryHandler>();

        #endregion
    }
}