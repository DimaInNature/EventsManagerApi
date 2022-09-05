namespace EMA.Domain.Commands.EventStates;

public sealed record CreateEventStateCommandHandler
    : IRequestHandler<CreateEventStateCommand, bool>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public CreateEventStateCommandHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateEventStateCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (EventStateEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}