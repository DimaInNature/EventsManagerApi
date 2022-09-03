namespace EMA.Domain.Commands.PresentationStates;

public sealed record CreatePresentationStateCommandHandler
    : IRequestHandler<CreatePresentationStateCommand, bool>
{
    private readonly IGenericRepository<PresentationStateEntity> _repository;

    public CreatePresentationStateCommandHandler(
        IGenericRepository<PresentationStateEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreatePresentationStateCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (PresentationStateEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}