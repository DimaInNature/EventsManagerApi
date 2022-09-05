namespace EMA.Domain.Commands.Events;

public sealed record DeleteEventCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteEventCommand(Guid id) => Id = id;

    public DeleteEventCommand() { }
}