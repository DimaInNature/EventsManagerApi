namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorQuery
    : IRequest<VisitorEntity>
{
    public Func<VisitorEntity, bool>? Predicate { get; }

    public Expression<Func<VisitorEntity, object>>[]? IncludeProperties { get; }

    public GetVisitorQuery(
        Func<VisitorEntity, bool> predicate,
        params Expression<Func<VisitorEntity, object>>[] includeProperties) =>
        (Predicate, IncludeProperties) = (predicate, includeProperties);

    public GetVisitorQuery() { }
}