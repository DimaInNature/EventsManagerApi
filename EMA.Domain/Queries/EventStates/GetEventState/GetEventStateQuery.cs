namespace EMA.Domain.Queries.EventStates;

public sealed record GetEventStateQuery
    : IRequest<EventStateEntity?>
{
    public Func<EventStateEntity, bool>? Predicate { get; }

    public GetEventStateQuery(
        Func<EventStateEntity, bool> predicate) =>
        Predicate = predicate;

    public GetEventStateQuery() { }
}