namespace EMA.Domain.Commands.EventStates;

public sealed record CreateEventStateCommand : IRequest<bool>
{
    public EventStateEntity? Entity { get; }

    public CreateEventStateCommand(
        EventStateEntity entity) => Entity = entity;

    public CreateEventStateCommand() { }
}