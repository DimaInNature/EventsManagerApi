namespace EMA.Domain.Commands.Visitors;

public sealed record UpdateVisitorCommand : IRequest<bool>
{
    public VisitorEntity? Entity { get; }

    public UpdateVisitorCommand(VisitorEntity entity) => Entity = entity;

    public UpdateVisitorCommand() { }
}