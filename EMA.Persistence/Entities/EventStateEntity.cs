namespace EMA.Persistence.Entities;

public class EventStateEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    [MaxLength(length: 50)]
    public string? Name { get; set; }

    [JsonIgnore]
    public IEnumerable<EventStateEntity>? Presentations { get; set; }
}