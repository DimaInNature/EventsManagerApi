namespace EMA.Domain.Commands.Events;

public sealed record DeleteEventsListCommandHandler
    : IRequestHandler<DeleteEventsListCommand, bool>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public DeleteEventsListCommandHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteEventsListCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Entities is null || request.Entities.Any() is false)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.DeleteAsync(request.Entities, cancellationToken);
    }
}