namespace EMA.Domain.Commands.EventStates;

public sealed record DeleteEventStateCommandHandler
    : IRequestHandler<DeleteEventStateCommand, bool>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public DeleteEventStateCommandHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteEventStateCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}