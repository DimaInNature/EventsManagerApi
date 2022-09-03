namespace EMA.Domain.Commands.VisitorGenders;

public sealed record DeleteVisitorGenderCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteVisitorGenderCommand(Guid id) => Id = id;

    public DeleteVisitorGenderCommand() { }
}