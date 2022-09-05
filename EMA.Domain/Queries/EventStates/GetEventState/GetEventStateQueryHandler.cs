namespace EMA.Domain.Queries.EventStates;

public sealed record GetEventStateQueryHandler
    : IRequestHandler<GetEventStateQuery, Option<EventStateEntity>>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public GetEventStateQueryHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<Option<EventStateEntity>> Handle(
        GetEventStateQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}