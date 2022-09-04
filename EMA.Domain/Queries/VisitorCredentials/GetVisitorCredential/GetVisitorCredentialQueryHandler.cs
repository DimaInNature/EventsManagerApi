namespace EMA.Domain.Queries.VisitorCredentials;

public sealed record GetVisitorCredentialQueryHandler
    : IRequestHandler<GetVisitorCredentialQuery, Option<VisitorCredentialEntity>>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public GetVisitorCredentialQueryHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<Option<VisitorCredentialEntity>> Handle(
        GetVisitorCredentialQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}