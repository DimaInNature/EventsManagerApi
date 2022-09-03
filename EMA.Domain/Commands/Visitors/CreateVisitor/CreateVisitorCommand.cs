namespace EMA.Domain.Commands.Visitors.CreateVisitor;

public sealed record CreateVisitorCommand : IRequest<bool>
{
    public Option<VisitorEntity> Entity { get; }

    public CreateVisitorCommand(VisitorEntity entity) => Entity = entity;

    public CreateVisitorCommand() { }
}