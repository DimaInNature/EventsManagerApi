namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationsListQueryHandler
    : IRequestHandler<GetPresentationsListQuery, IEnumerable<PresentationEntity>>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public GetPresentationsListQueryHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<PresentationEntity>> Handle(
        GetPresentationsListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}