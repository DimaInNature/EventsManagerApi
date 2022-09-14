namespace EMA.Persistence.Entities;

public class VisitorGenderEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    [MaxLength(length: 50)]
    public string? Name { get; set; }

    [JsonIgnore]
    public IEnumerable<VisitorEntity>? Visitors { get; set; }
}