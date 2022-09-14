namespace EMA.Domain.Commands.VisitorContacts;

public sealed record UpdateVisitorContactCommandHandler
    : IRequestHandler<UpdateVisitorContactCommand, bool>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public UpdateVisitorContactCommandHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVisitorContactCommand request,
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