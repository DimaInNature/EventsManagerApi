namespace EMA.Persistence.Entities;

public class VisitorContactEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    [MaxLength(length: 20)]
    public string? Phone { get; set; }

    [MaxLength(length: 50)]
    public string? Email { get; set; }

    [JsonIgnore]
    public VisitorEntity? Visitor { get; set; }
}