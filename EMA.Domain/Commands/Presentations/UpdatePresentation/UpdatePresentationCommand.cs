namespace EMA.Domain.Commands.Presentations;

public sealed record UpdatePresentationCommand : IRequest<bool>
{
    public Option<PresentationEntity> Entity { get; }

    public UpdatePresentationCommand(
        PresentationEntity entity) => Entity = entity;

    public UpdatePresentationCommand() { }
}