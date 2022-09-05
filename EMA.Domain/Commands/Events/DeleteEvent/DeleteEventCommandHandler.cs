namespace EMA.Domain.Commands.Events;

public sealed record DeleteEventCommandHandler
    : IRequestHandler<DeleteEventCommand, bool>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public DeleteEventCommandHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteEventCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}