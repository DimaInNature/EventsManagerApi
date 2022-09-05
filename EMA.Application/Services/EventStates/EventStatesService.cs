namespace EMA.Application.Services.EventStates;

public class EventStatesService : IEventStatesService
{
    private readonly IMediator _mediator;

    public EventStatesService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<EventStateEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetEventStatesListQuery(), cancellationToken);

    public async Task<Option<EventStateEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetEventStateQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task CreateAsync(EventStateEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateEventStateCommand(entity), cancellationToken);

    public async Task UpdateAsync(EventStateEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateEventStateCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteEventStateCommand(id), cancellationToken);
}