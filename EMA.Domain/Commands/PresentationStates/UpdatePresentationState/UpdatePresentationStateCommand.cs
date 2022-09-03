namespace EMA.Domain.Commands.PresentationStates;

public sealed record UpdatePresentationStateCommand : IRequest<bool>
{
    public Option<PresentationStateEntity> Entity { get; }

    public UpdatePresentationStateCommand(
        PresentationStateEntity entity) => Entity = entity;

    public UpdatePresentationStateCommand() { }
}