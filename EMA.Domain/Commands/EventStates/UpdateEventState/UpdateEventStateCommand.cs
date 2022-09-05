namespace EMA.Domain.Commands.EventStates;

public sealed record UpdateEventStateCommand : IRequest<bool>
{
    public Option<EventStateEntity> Entity { get; }

    public UpdateEventStateCommand(
        EventStateEntity entity) => Entity = entity;

    public UpdateEventStateCommand() { }
}