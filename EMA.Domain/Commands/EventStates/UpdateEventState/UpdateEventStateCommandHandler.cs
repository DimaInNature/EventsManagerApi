namespace EMA.Domain.Commands.EventStates;

public sealed record UpdateEventStateCommandHandler
    : IRequestHandler<UpdateEventStateCommand, bool>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public UpdateEventStateCommandHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateEventStateCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (EventStateEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}