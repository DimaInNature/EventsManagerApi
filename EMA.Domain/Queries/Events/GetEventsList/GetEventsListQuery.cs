namespace EMA.Domain.Queries.Events;

public sealed record GetEventsListQuery
    : IRequest<IEnumerable<EventEntity>>
{
    public Expression<Func<EventEntity, object>>[]? IncludeProperties { get; }

    public GetEventsListQuery(
       params Expression<Func<EventEntity, object>>[] includeProperties) =>
        IncludeProperties = includeProperties;

    public GetEventsListQuery() { }
}