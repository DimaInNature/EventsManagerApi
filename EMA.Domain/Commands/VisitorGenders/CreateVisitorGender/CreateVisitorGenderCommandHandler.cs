namespace EMA.Domain.Commands.VisitorGenders;

public sealed record CreateVisitorGenderCommandHandler
    : IRequestHandler<CreateVisitorGenderCommand, bool>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public CreateVisitorGenderCommandHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorGenderCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorGenderEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}