namespace EMA.Domain.Commands.VisitorContacts;

public sealed record DeleteVisitorContactCommandHandler
    : IRequestHandler<DeleteVisitorContactCommand, bool>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public DeleteVisitorContactCommandHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVisitorContactCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}