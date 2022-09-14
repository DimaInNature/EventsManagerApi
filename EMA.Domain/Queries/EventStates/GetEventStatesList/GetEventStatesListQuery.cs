namespace EMA.Domain.Queries.EventStates;

public sealed record GetEventStatesListQuery
    : IRequest<IEnumerable<EventStateEntity>>
{
    public Func<EventStateEntity, bool>? Predicate { get; }

    public GetEventStatesListQuery(
        Func<EventStateEntity, bool> predicate) =>
        Predicate = predicate;

    public GetEventStatesListQuery() { }
}