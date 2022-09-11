namespace EMA.Domain.Queries.Events;

public sealed record GetEventQuery
    : IRequest<EventEntity?>
{
    public Func<EventEntity, bool>? Predicate { get; }

    public Expression<Func<EventEntity, object>>[]? IncludeProperties { get; }

    public GetEventQuery(
        Func<EventEntity, bool> predicate,
        params Expression<Func<EventEntity, object>>[] includeProperties) =>
        (Predicate, IncludeProperties) = (predicate, includeProperties);

    public GetEventQuery() { }
}