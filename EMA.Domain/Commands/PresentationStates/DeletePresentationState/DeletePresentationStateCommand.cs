namespace EMA.Domain.Commands.PresentationStates;

public sealed record DeletePresentationStateCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeletePresentationStateCommand(Guid id) => Id = id;

    public DeletePresentationStateCommand() { }
}