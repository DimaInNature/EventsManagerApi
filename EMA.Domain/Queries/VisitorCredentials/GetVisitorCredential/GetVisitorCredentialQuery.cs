namespace EMA.Domain.Queries.VisitorCredentials;

public sealed record GetVisitorCredentialQuery
    : IRequest<Option<VisitorCredentialEntity>>
{
    public Option<Func<VisitorCredentialEntity, bool>> Predicate { get; }

    public GetVisitorCredentialQuery(
        Func<VisitorCredentialEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorCredentialQuery() { }
}