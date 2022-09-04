namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationListQueryHandler
    : IRequestHandler<GetPresentationListQuery, IEnumerable<PresentationEntity>>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public GetPresentationListQueryHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<PresentationEntity>> Handle(
        GetPresentationListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}