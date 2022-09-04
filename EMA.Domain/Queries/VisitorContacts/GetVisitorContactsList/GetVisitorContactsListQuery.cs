namespace EMA.Domain.Queries.VisitorContacts;

public sealed record GetVisitorContactsListQuery
    : IRequest<IEnumerable<VisitorContactEntity>>
{
    public Option<Func<VisitorContactEntity, bool>> Predicate { get; }

    public GetVisitorContactsListQuery(
        Func<VisitorContactEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorContactsListQuery() { }
}