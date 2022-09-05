namespace EMA.Domain.Queries.EventStates;

public sealed record GetEventStatesListQueryHandler
    : IRequestHandler<GetEventStatesListQuery, IEnumerable<EventStateEntity>>
{
    private readonly IGenericRepository<EventStateEntity> _repository;

    public GetEventStatesListQueryHandler(
        IGenericRepository<EventStateEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<EventStateEntity>> Handle(
        GetEventStatesListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}