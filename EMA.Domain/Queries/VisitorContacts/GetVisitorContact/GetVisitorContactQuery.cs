namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactQuery
    : IRequest<VisitorContactEntity?>
{
    public Func<VisitorContactEntity, bool>? Predicate { get; }

    public GetVisitorContactQuery(
        Func<VisitorContactEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorContactQuery() { }
}