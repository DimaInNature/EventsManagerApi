namespace EMA.Domain.Queries.EventStates;

public sealed record GetEventStateQueryHandler
    : IRequestHandler<GetEventStateQuery, EventStateEntity?>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public GetEventStateQueryHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<EventStateEntity?> Handle(
        GetEventStateQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
        {
            return default;
        }

        return await Task.FromResult(
            result: _repository.GetFirstOrDefault(
                predicate: request.Predicate));
    }
}