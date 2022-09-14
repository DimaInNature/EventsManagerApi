namespace EMA.Application.Services.Visitors;

public class VisitorsService : IVisitorsService
{
    private readonly IMediator _mediator;

    public VisitorsService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<VisitorEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorsListQuery(), cancellationToken);

    public async Task<VisitorEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task<VisitorEntity?> GetAsync(Guid id,
      CancellationToken cancellationToken = default,
      params Expression<Func<VisitorEntity, object>>[] includes) =>
      await _mediator.Send(request: new GetVisitorQuery(
          predicate: entity => entity.Id.Equals(g: id), includes), cancellationToken);

    public async Task CreateAsync(VisitorEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateVisitorCommand(entity), cancellationToken);

    public async Task UpdateAsync(VisitorEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateVisitorCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteVisitorCommand(id), cancellationToken);
}