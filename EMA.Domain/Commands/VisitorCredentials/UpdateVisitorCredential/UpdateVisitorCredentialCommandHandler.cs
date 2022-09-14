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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.UpdateAsync(
            entity: request.Entity, cancellationToken);
    }
}