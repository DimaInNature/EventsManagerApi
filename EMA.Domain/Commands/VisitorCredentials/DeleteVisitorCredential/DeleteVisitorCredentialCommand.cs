namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record DeleteVisitorCredentialCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteVisitorCredentialCommand(Guid id) => Id = id;

    public DeleteVisitorCredentialCommand() { }
}