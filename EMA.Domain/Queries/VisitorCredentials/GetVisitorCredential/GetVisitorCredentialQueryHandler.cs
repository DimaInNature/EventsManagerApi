namespace EMA.Domain.Queries.VisitorCredentials;

public sealed record GetVisitorCredentialQueryHandler
    : IRequestHandler<GetVisitorCredentialQuery, VisitorCredentialEntity?>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public GetVisitorCredentialQueryHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<VisitorCredentialEntity?> Handle(
        GetVisitorCredentialQuery request,
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