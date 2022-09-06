namespace EMA.Persistence.Entities;

public class VisitorEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public Guid? CredentialsId { get; set; }

    [JsonIgnore]
    public VisitorCredentialEntity? Credentials { get; set; }

    public Guid? GenderId { get; set; }

    [JsonIgnore]
    public VisitorGenderEntity? Gender { get; set; }

    [JsonIgnore]
    public Guid? ContactId { get; set; }

    [JsonIgnore]
    public VisitorContactEntity? Contact { get; set; }

    public Guid? EventId { get; set; }

    [JsonIgnore]
    public EventEntity? Event { get; set; }
}