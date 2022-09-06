namespace EMA.Persistence.Entities;

public class VisitorGenderEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public IEnumerable<VisitorEntity>? Visitors { get; set; }
}