namespace EMA.Domain.Queries.Events;

public sealed record GetEventWithIncludeQueryHandler
    : IRequestHandler<GetEventWithIncludeQuery, EventEntity?>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public GetEventWithIncludeQueryHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<EventEntity?> Handle(
        GetEventWithIncludeQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null || request.Includes is null)
            return default;

        return _repository.GetFirstOrDefaultWithInclude(
            predicate: request.Predicate,
            includeProperties: request.Includes);
    }
}