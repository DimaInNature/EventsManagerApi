namespace EMA.Domain.Commands.Visitors;

public sealed record UpdateVisitorCommand : IRequest<bool>
{
    public Option<VisitorEntity> Entity { get; }

    public UpdateVisitorCommand(VisitorEntity entity) => Entity = entity;

    public UpdateVisitorCommand() { }
}