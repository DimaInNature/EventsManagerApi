namespace EMA.Domain.Commands.Visitors;

public sealed record DeleteVisitorCommandHandler
    : IRequestHandler<DeleteVisitorCommand, bool>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public DeleteVisitorCommandHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVisitorCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}