namespace EMA.Domain.Commands.Events;

public sealed record DeleteEventsListCommand : IRequest<bool>
{
    public IEnumerable<EventEntity>? Entities { get; }

    public DeleteEventsListCommand(
        IEnumerable<EventEntity> entities) => Entities = entities;

    public DeleteEventsListCommand() { }
}