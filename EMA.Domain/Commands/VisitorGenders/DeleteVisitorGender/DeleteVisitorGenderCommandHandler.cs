namespace EMA.Domain.Commands.VisitorGenders;

public sealed record DeleteVisitorGenderCommandHandler
    : IRequestHandler<DeleteVisitorGenderCommand, bool>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public DeleteVisitorGenderCommandHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVisitorGenderCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}