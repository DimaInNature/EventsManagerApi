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