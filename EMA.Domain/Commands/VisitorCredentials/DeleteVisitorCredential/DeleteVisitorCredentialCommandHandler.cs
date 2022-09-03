namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record DeleteVisitorCredentialCommandHandler
    : IRequestHandler<DeleteVisitorCredentialCommand, bool>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public DeleteVisitorCredentialCommandHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVisitorCredentialCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}