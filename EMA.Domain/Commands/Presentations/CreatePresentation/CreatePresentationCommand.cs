namespace EMA.Domain.Commands.Presentations;

public sealed record CreatePresentationCommand : IRequest<bool>
{
    public Option<PresentationEntity> Entity { get; }

    public CreatePresentationCommand(
        PresentationEntity entity) => Entity = entity;

    public CreatePresentationCommand() { }
}