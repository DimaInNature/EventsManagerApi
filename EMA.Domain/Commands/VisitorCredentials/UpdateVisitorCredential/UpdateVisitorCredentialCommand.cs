namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record UpdateVisitorCredentialCommand : IRequest<bool>
{
    public VisitorCredentialEntity? Entity { get; }

    public UpdateVisitorCredentialCommand(
        VisitorCredentialEntity entity) => Entity = entity;

    public UpdateVisitorCredentialCommand() { }
}