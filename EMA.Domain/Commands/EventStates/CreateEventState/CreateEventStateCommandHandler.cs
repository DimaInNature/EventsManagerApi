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