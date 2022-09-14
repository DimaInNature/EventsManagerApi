namespace EMA.Domain.Queries.VisitorCredentials;

public sealed record GetVisitorCredentialQuery
    : IRequest<VisitorCredentialEntity?>
{
    public Func<VisitorCredentialEntity, bool>? Predicate { get; }

    public GetVisitorCredentialQuery(
        Func<VisitorCredentialEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorCredentialQuery() { }
}