namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorsListQueryHandler
    : IRequestHandler<GetVisitorsListQuery, IEnumerable<VisitorEntity>>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public GetVisitorsListQueryHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VisitorEntity>> Handle(
        GetVisitorsListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}