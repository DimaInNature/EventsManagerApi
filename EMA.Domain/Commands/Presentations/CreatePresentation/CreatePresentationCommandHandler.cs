namespace EMA.Domain.Commands.Presentations;

public sealed record CreatePresentationCommandHandler
    : IRequestHandler<CreatePresentationCommand, bool>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public CreatePresentationCommandHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreatePresentationCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (PresentationEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}