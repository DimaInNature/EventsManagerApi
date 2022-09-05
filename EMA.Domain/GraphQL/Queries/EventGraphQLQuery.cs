namespace EMA.Domain.GraphQL.Queries;

public class EventGraphQLQuery
{
	private readonly IGenericRepository<EventEntity> _context;

	public EventGraphQLQuery(
		IGenericRepository<EventEntity> context)
	{
		_context = context;
	}

	[UseProjection]
	[UseSorting]
	[UseFiltering]
	public IEnumerable<EventEntity> GetEventsList() =>
		_context.GetAll();
}