﻿namespace EMA.Domain.Commands.VisitorGenders;

public sealed record UpdateVisitorGenderCommand : IRequest<bool>
{
    public Option<VisitorGenderEntity> Entity { get; }

    public UpdateVisitorGenderCommand(VisitorGenderEntity entity) => Entity = entity;

    public UpdateVisitorGenderCommand() { }
}