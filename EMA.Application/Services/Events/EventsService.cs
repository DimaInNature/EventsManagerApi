namespace EMA.Application.Services.Events;

public class EventsService : IEventsService
{
    private readonly IMediator _mediator;

    public EventsService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetEventsListQuery(), cancellationToken);

    public async Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<EventEntity, object>>[] includeProperties) =>
        await _mediator.Send(request: new GetEventsListQuery(includeProperties));

    public async Task<EventEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetEventQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task<EventEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default,
        params Expression<Func<EventEntity, object>>[] includes) =>
        await _mediator.Send(request: new GetEventQuery(
            predicate: entity => entity.Id.Equals(g: id), includes), cancellationToken);

    public async Task CreateAsync(EventEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateEventCommand(entity), cancellationToken);

    public async Task UpdateAsync(EventEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateEventCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteEventCommand(id), cancellationToken);
}