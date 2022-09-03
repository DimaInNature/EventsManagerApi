namespace EMA.Domain.Commands.PresentationStates;

public sealed record DeletePresentationStateCommandHandler
    : IRequestHandler<DeletePresentationStateCommand, bool>
{
    private readonly IGenericRepository<PresentationStateEntity> _repository;

    public DeletePresentationStateCommandHandler(
        IGenericRepository<PresentationStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeletePresentationStateCommand request,
        CancellationToken cancellationToken = default) =>
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}