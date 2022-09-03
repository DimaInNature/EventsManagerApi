namespace EMA.Persistence.Entities;

public class VisitorCredentialEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Patronymic { get; set; }

    public DateOnly? BirthDay { get; set; }

    public VisitorEntity? Visitor;
}