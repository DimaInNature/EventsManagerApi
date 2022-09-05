namespace EMA.Domain.Queries.Events;

public sealed record GetEventQueryHandler
    : IRequestHandler<GetEventQuery, Option<EventEntity>>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public GetEventQueryHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<Option<EventEntity>> Handle(
        GetEventQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}