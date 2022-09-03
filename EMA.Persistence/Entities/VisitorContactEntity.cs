namespace EMA.Persistence.Entities;

public class VisitorContactEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public VisitorEntity? Visitor { get; set; }
}