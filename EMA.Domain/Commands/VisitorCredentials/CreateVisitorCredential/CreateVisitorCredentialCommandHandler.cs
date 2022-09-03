namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record CreateVisitorCredentialCommandHandler
    : IRequestHandler<CreateVisitorCredentialCommand, bool>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public CreateVisitorCredentialCommandHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorCredentialCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorCredentialEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}