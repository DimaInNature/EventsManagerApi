namespace EMA.Domain.Commands.VisitorContacts;

public sealed record UpdateVisitorContactCommand : IRequest<bool>
{
    public VisitorContactEntity? Entity { get; }

    public UpdateVisitorContactCommand(
        VisitorContactEntity entity) => Entity = entity;

    public UpdateVisitorContactCommand() { }
}