namespace EMA.Domain.Commands.EventStates;

public sealed record DeleteEventStateCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteEventStateCommand(Guid id) => Id = id;

    public DeleteEventStateCommand() { }
}