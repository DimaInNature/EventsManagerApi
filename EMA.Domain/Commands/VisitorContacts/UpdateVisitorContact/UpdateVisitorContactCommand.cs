namespace EMA.Domain.Commands.VisitorContacts;

public sealed record UpdateVisitorContactCommand : IRequest<bool>
{
    public Option<VisitorContactEntity> Entity { get; }

    public UpdateVisitorContactCommand(
        VisitorContactEntity entity) => Entity = entity;

    public UpdateVisitorContactCommand() { }
}