namespace EMA.Application.Services.VisitorGenders;

public class VisitorGendersService : IVisitorGendersService
{
    private readonly IMediator _mediator;

    public VisitorGendersService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<VisitorGenderEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorGendersListQuery(), cancellationToken);

    public async Task<VisitorGenderEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorGenderQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task CreateAsync(VisitorGenderEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateVisitorGenderCommand(entity), cancellationToken);

    public async Task UpdateAsync(VisitorGenderEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateVisitorGenderCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteVisitorGenderCommand(id), cancellationToken);
}