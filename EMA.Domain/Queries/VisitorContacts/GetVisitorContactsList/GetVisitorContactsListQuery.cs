namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactsListQuery
    : IRequest<IEnumerable<VisitorContactEntity>>
{
    public Func<VisitorContactEntity, bool>? Predicate { get; }

    public GetVisitorContactsListQuery(
        Func<VisitorContactEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorContactsListQuery() { }
}