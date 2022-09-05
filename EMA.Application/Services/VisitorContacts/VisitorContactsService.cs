namespace EMA.Application.Services.VisitorContacts;

public class VisitorContactsService : IVisitorContactsService
{
    private readonly IMediator _mediator;

    public VisitorContactsService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<VisitorContactEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorContactsListQuery(), cancellationToken);

    public async Task<Option<VisitorContactEntity>> GetAsync(Guid id,
         CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorContactQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task CreateAsync(VisitorContactEntity entity,
         CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateVisitorContactCommand(entity), cancellationToken);

    public async Task UpdateAsync(VisitorContactEntity entity,
         CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateVisitorContactCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteVisitorContactCommand(id));
}