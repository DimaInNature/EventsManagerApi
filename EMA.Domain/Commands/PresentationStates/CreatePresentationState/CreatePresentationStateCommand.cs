namespace EMA.Domain.Commands.PresentationStates;

public sealed record CreatePresentationStateCommand : IRequest<bool>
{
    public Option<PresentationStateEntity> Entity { get; }

    public CreatePresentationStateCommand(
        PresentationStateEntity entity) => Entity = entity;

    public CreatePresentationStateCommand() { }
}