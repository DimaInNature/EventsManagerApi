namespace EMA.Domain.Commands.Events;

public sealed record CreateEventCommand : IRequest<bool>
{
    public EventEntity? Entity { get; }

    public CreateEventCommand(
        EventEntity entity) => Entity = entity;

    public CreateEventCommand() { }
}