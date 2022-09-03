namespace EMA.Domain.Commands.Visitors;

public sealed record DeleteVisitorCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteVisitorCommand(Guid id) => Id = id;

    public DeleteVisitorCommand() { }
}