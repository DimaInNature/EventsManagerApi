namespace EMA.Domain.Commands.PresentationStates;

public sealed record UpdatePresentationStateCommandHandler
    : IRequestHandler<UpdatePresentationStateCommand, bool>
{
    private readonly IGenericRepository<PresentationStateEntity> _repository;

    public UpdatePresentationStateCommandHandler(
        IGenericRepository<PresentationStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdatePresentationStateCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (PresentationStateEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}