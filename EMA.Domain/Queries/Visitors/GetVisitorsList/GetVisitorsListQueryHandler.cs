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
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
        {
            return await Task.FromResult(result: _repository.GetAll());
        }

        return await Task.FromResult(
            result: _repository.GetAll(
                predicate: request.Predicate));
    }
}