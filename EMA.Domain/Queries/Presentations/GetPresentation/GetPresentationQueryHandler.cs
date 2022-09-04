namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationQueryHandler
    : IRequestHandler<GetPresentationQuery, Option<PresentationEntity>>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public GetPresentationQueryHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<Option<PresentationEntity>> Handle(
        GetPresentationQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}