namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record UpdateVisitorCredentialCommandHandler
    : IRequestHandler<UpdateVisitorCredentialCommand, bool>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public UpdateVisitorCredentialCommandHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVisitorCredentialCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorCredentialEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}