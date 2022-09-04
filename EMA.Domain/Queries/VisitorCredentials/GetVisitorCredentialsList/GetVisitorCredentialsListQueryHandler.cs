namespace EMA.Domain.Queries.VisitorCredentials;

public sealed record GetVisitorCredentialsListQueryHandler
    : IRequestHandler<GetVisitorCredentialsListQuery, IEnumerable<VisitorCredentialEntity>>
{
    private readonly IGenericRepository<VisitorCredentialEntity> _repository;

    public GetVisitorCredentialsListQueryHandler(
        IGenericRepository<VisitorCredentialEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VisitorCredentialEntity>> Handle(
        GetVisitorCredentialsListQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}