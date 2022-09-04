namespace EMA.Domain.Queries.PresentationStates;

public sealed record GetPresentationStatesListQueryHandler
    : IRequestHandler<GetPresentationStatesListQuery, IEnumerable<PresentationStateEntity>>
{
    private readonly IGenericRepository<PresentationStateEntity> _repository;

    public GetPresentationStatesListQueryHandler(
        IGenericRepository<PresentationStateEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<PresentationStateEntity>> Handle(
        GetPresentationStatesListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}