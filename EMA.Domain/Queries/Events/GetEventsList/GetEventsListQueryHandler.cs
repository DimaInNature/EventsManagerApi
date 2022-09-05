namespace EMA.Domain.Queries.Events;

public sealed record GetEventsListQueryHandler
    : IRequestHandler<GetEventsListQuery, IEnumerable<EventEntity>>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public GetEventsListQueryHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<EventEntity>> Handle(
        GetEventsListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}