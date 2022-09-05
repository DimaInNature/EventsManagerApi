namespace EMA.Domain.Queries.Events;

public sealed record GetEventsListQuery
    : IRequest<IEnumerable<EventEntity>>
{
    public Option<Func<EventEntity, bool>> Predicate { get; }

    public GetEventsListQuery(
        Func<EventEntity, bool> predicate) =>
        Predicate = predicate;

    public GetEventsListQuery() { }
}