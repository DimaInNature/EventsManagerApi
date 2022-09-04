namespace EMA.Domain.Queries.Visitors;

public sealed record GetVisitorQuery
    : IRequest<Option<VisitorEntity>>
{
    public Option<Func<VisitorEntity, bool>> Predicate { get; }

    public GetVisitorQuery(
        Func<VisitorEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorQuery() { }
}