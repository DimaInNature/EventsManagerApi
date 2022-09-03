namespace EMA.Domain.Commands.VisitorContacts;

public sealed record class DeleteVisitorContactCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteVisitorContactCommand(Guid id) => Id = id;

    public DeleteVisitorContactCommand() { }
}