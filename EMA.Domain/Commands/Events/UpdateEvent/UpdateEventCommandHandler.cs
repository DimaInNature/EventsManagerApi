namespace EMA.Domain.Commands.Events;

public sealed record UpdateEventCommandHandler
    : IRequestHandler<UpdateEventCommand, bool>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public UpdateEventCommandHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateEventCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (EventEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}