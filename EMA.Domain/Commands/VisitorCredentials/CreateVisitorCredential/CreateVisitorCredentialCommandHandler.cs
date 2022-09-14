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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.CreateAsync(
            entity: request.Entity, cancellationToken);
    }
}