namespace EMA.Domain.Commands.Events;

public sealed record CreateEventCommandHandler
    : IRequestHandler<CreateEventCommand, bool>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public CreateEventCommandHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateEventCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (EventEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}