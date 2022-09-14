namespace EMA.Domain.Commands.EventStates;

public sealed record UpdateEventStateCommand : IRequest<bool>
{
    public EventStateEntity? Entity { get; }

    public UpdateEventStateCommand(
        EventStateEntity entity) => Entity = entity;

    public UpdateEventStateCommand() { }
}