namespace EMA.Persistence.Entities;

public class EventStateEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public IEnumerable<EventStateEntity>? Presentations { get; set; }
}