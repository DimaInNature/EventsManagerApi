namespace EMA.Domain.Commands.VisitorCredentials;

public sealed record CreateVisitorCredentialCommand : IRequest<bool>
{
    public VisitorCredentialEntity? Entity { get; }

    public CreateVisitorCredentialCommand(
        VisitorCredentialEntity entity) => Entity = entity;

    public CreateVisitorCredentialCommand() { }
}