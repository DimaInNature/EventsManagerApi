namespace EMA.Persistence.Entities;

public class VisitorEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public Guid? CredentialsId { get; set; }

    public VisitorCredentialEntity? Credentials { get; set; }

    public Guid? GenderId { get; set; }

    public VisitorGenderEntity? Gender { get; set; }

    public Guid? ContactId { get; set; }

    public VisitorContactEntity? Contact { get; set; }

    public Guid? EventId { get; set; }

    public EventEntity? Event { get; set; }
}