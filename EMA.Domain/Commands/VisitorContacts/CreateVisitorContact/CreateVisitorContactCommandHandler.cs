namespace EMA.Domain.Commands.VisitorContacts;

public sealed record CreateVisitorContactCommandHandler
    : IRequestHandler<CreateVisitorContactCommand, bool>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public CreateVisitorContactCommandHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorContactCommand request,
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