namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactsListQueryHandler
    : IRequestHandler<GetVisitorContactsListQuery, IEnumerable<VisitorContactEntity>>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public GetVisitorContactsListQueryHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VisitorContactEntity>> Handle(
        GetVisitorContactsListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}