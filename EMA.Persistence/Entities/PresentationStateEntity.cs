namespace EMA.Persistence.Entities;

public class PresentationStateEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public IEnumerable<PresentationStateEntity>? Presentations { get; set; }
}