namespace EMA.Domain.Commands.Presentations;

public sealed record DeletePresentationCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeletePresentationCommand(Guid id) => Id = id;

    public DeletePresentationCommand() { }
}