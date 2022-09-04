namespace EMA.Domain.Queries.PresentationStates;

public sealed record GetPresentationStateQueryHandler
    : IRequestHandler<GetPresentationStateQuery, Option<PresentationStateEntity>>
{
    private readonly IGenericRepository<PresentationStateEntity> _repository;

    public GetPresentationStateQueryHandler(
        IGenericRepository<PresentationStateEntity> repository) =>
        _repository = repository;

    public async Task<Option<PresentationStateEntity>> Handle(
        GetPresentationStateQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}