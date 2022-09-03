namespace EMA.Domain.Commands.Presentations;

public sealed record DeletePresentationCommandHandler
    : IRequestHandler<DeletePresentationCommand, bool>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public DeletePresentationCommandHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeletePresentationCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}