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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.UpdateAsync(
            entity: request.Entity, cancellationToken);
    }
}