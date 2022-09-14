namespace EMA.Domain.Commands.Events;

public sealed record UpdateEventCommand : IRequest<bool>
{
    public EventEntity? Entity { get; }

    public UpdateEventCommand(
        EventEntity entity) => Entity = entity;

    public UpdateEventCommand() { }
}