namespace EMA.Domain.Core.Models.Responses.Events;

public record FinishEventResponse
{
    public Guid EventId { get; set; }

    public Guid StateId { get; set; }
}