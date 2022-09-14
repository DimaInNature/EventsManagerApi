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