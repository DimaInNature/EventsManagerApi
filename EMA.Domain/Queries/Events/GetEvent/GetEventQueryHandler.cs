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
        if (request.Predicate is null || request.Includes is null)
            return default;

        return _repository.GetFirstOrDefaultWithInclude(
            predicate: request.Predicate,
            includeProperties: request.Includes);
    }
}