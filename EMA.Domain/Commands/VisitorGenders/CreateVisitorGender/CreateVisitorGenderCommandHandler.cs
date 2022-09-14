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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.CreateAsync(
            entity: request.Entity, cancellationToken);
    }
}