namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactQueryHandler
    : IRequestHandler<GetVisitorContactQuery, VisitorContactEntity?>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public GetVisitorContactQueryHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<VisitorContactEntity?> Handle(
        GetVisitorContactQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
        {
            return default;
        }

        return await Task.FromResult(
            result: _repository.GetFirstOrDefault(
                predicate: request.Predicate));
    }
}