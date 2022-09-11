namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorQueryHandler
    : IRequestHandler<GetVisitorQuery, VisitorEntity?>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public GetVisitorQueryHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<VisitorEntity?> Handle(
        GetVisitorQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
            return await Task.FromResult(result: default(VisitorEntity?));

        if (request.IncludeProperties is null)
            return await Task.FromResult(
                result: _repository.GetFirstOrDefault(
                    predicate: request.Predicate));

        return await Task.FromResult(
            result: _repository.GetFirstOrDefaultWithInclude(
                predicate: request.Predicate,
                includeProperties: request.IncludeProperties));
    }
}