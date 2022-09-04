namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactQueryHandler
    : IRequestHandler<GetVisitorContactQuery, Option<VisitorContactEntity>>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public GetVisitorContactQueryHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<Option<VisitorContactEntity>> Handle(
        GetVisitorContactQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}