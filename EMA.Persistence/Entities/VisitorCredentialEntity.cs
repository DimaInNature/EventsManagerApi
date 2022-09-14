namespace EMA.Persistence.Entities;

public class VisitorCredentialEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    [MaxLength(length: 50)]
    public string? Name { get; set; }

    [MaxLength(length: 50)]
    public string? LastName { get; set; }

    [MaxLength(length: 50)]
    public string? Patronymic { get; set; }

    public DateOnly? BirthDay { get; set; }

    [JsonIgnore]
    public VisitorEntity? Visitor;
}