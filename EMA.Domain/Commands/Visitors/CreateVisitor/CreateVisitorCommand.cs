namespace EMA.Domain.Commands.Visitors;

public sealed record CreateVisitorCommand : IRequest<bool>
{
    public VisitorEntity? Entity { get; }

    public CreateVisitorCommand(VisitorEntity entity) => Entity = entity;

    public CreateVisitorCommand() { }
}