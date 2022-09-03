namespace EMA.Persistence.Entities;

public class PresentationEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public Guid? StateId { get; set; }

    public PresentationStateEntity? State { get; set; }

    public IEnumerable<VisitorEntity>? Members { get; set; }
}