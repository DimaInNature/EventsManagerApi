namespace EMA.Domain.Queries.Events;

public sealed record GetEventQueryHandler
    : IRequestHandler<GetEventQuery, EventEntity?>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public GetEventQueryHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<EventEntity?> Handle(
        GetEventQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
            return await Task.FromResult(result: default(EventEntity?));

        if (request.IncludeProperties is null)
            return await Task.FromResult(
                result: _repository.GetFirstOrDefault(
                    predicate: request.Predicate));

        return await Task.FromResult(
            result: _repository.GetFirstOrDefaultWithInclude(
                predicate: request.Predicate,
                includeProperties: request.IncludeProperties));
    }
}