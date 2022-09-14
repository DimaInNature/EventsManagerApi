namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorsListQuery
    : IRequest<IEnumerable<VisitorEntity>>
{
    public Func<VisitorEntity, bool>? Predicate { get; }

    public GetVisitorsListQuery(
        Func<VisitorEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorsListQuery() { }
}