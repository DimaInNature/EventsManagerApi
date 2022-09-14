namespace EMA.Domain.Commands.VisitorContacts;

public sealed record CreateVisitorContactCommand : IRequest<bool>
{
    public VisitorContactEntity? Entity { get; }

    public CreateVisitorContactCommand(
        VisitorContactEntity entity) => Entity = entity;

    public CreateVisitorContactCommand() { }
}