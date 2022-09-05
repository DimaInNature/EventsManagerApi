namespace EMA.Persistence.Entities;

public class EventEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public Guid? StateId { get; set; }

    public EventStateEntity? State { get; set; }

    public IEnumerable<VisitorEntity>? Members { get; set; }
}