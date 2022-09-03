namespace EMA.Domain.Commands.VisitorGenders;

public sealed record UpdateVisitorGenderCommandHandler
    : IRequestHandler<UpdateVisitorGenderCommand, bool>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public UpdateVisitorGenderCommandHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVisitorGenderCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorGenderEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}