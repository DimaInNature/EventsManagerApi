namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorQueryHandler
    : IRequestHandler<GetVisitorQuery, Option<VisitorEntity>>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public GetVisitorQueryHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<Option<VisitorEntity>> Handle(
        GetVisitorQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}