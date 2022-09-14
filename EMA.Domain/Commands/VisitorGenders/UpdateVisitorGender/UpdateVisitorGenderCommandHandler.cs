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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.UpdateAsync(
            entity: request.Entity, cancellationToken);
    }
}