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