namespace EMA.Application.Services.VisitorCredentials;

public class VisitorCredentialsService : IVisitorCredentialsService
{
    private readonly IMediator _mediator;

    public VisitorCredentialsService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<VisitorCredentialEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorCredentialsListQuery(), cancellationToken);

    public async Task<VisitorCredentialEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new GetVisitorCredentialQuery(
            predicate: entity => entity.Id.Equals(g: id)), cancellationToken);

    public async Task CreateAsync(VisitorCredentialEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new CreateVisitorCredentialCommand(entity), cancellationToken);

    public async Task UpdateAsync(VisitorCredentialEntity entity,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new UpdateVisitorCredentialCommand(entity), cancellationToken);

    public async Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default) =>
        await _mediator.Send(request: new DeleteVisitorCredentialCommand(id), cancellationToken);
}