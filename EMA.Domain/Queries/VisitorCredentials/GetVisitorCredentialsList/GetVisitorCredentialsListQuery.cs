namespace EMA.Domain.Queries.VisitorCredentials;

public sealed class GetVisitorCredentialsListQuery
    : IRequest<IEnumerable<VisitorCredentialEntity>>
{
    public Option<Func<VisitorCredentialEntity, bool>> Predicate { get; }

    public GetVisitorCredentialsListQuery(
        Func<VisitorCredentialEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorCredentialsListQuery() { }
}