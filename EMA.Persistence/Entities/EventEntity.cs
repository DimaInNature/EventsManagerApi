namespace EMA.Persistence.Entities;

public class EventEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    [MaxLength(length: 50)]
    public string? Name { get; set; }

    [MaxLength(length: 300)]
    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public Guid? StateId { get; set; }

    [JsonIgnore]
    public EventStateEntity? State { get; set; }

    [JsonIgnore]
    public IEnumerable<VisitorEntity>? Members { get; set; }
}