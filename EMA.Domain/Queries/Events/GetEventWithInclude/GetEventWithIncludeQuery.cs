namespace EMA.Domain.Queries.Events;

public sealed record GetEventWithIncludeQuery 
    : IRequest<EventEntity?>
{
    public Func<EventEntity, bool>? Predicate { get; }

    public Expression<Func<EventEntity, object>>[]? Includes { get; }

    public GetEventWithIncludeQuery(
        Func<EventEntity, bool> predicate, 
        params Expression<Func<EventEntity, object>>[] includes) =>
        (Predicate, Includes) = (predicate, includes);

    public GetEventWithIncludeQuery() { }
}