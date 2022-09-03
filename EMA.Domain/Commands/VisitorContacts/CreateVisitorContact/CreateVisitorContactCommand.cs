namespace EMA.Domain.Commands.VisitorContacts;

public sealed record CreateVisitorContactCommand : IRequest<bool>
{
    public Option<VisitorContactEntity> Entity { get; }

    public CreateVisitorContactCommand(
        VisitorContactEntity entity) => Entity = entity;

    public CreateVisitorContactCommand() { }
}