namespace EMA.Domain.Core.Models.Responses.Events;

public record CreateEventMemberResponse
{
    public VisitorEntity? Member { get; set; }

    public Guid EventId { get; set; }
}