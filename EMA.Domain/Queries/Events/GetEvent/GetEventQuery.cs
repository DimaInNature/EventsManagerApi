namespace EMA.Domain.Queries.Events;

public sealed record GetEventQuery
    : IRequest<Option<EventEntity>>
{
    public Option<Func<EventEntity, bool>> Predicate { get; }

    public GetEventQuery(
        Func<EventEntity, bool> predicate) =>
        Predicate = predicate;

    public GetEventQuery() { }
}