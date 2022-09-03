namespace EMA.Domain.Commands.VisitorGenders;

public sealed record CreateVisitorGenderCommand : IRequest<bool>
{
    public Option<VisitorGenderEntity> Entity { get; }

    public CreateVisitorGenderCommand(VisitorGenderEntity entity) => Entity = entity;

    public CreateVisitorGenderCommand() { }
}