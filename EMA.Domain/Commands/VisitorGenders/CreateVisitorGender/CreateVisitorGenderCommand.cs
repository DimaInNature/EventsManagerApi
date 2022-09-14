namespace EMA.Domain.Commands.VisitorGenders;

public sealed record CreateVisitorGenderCommand : IRequest<bool>
{
    public VisitorGenderEntity? Entity { get; }

    public CreateVisitorGenderCommand(VisitorGenderEntity entity) => Entity = entity;

    public CreateVisitorGenderCommand() { }
}