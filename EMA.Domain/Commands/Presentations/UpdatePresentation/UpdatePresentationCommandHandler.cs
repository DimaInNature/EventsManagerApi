namespace EMA.Domain.Commands.Presentations;

public sealed record UpdatePresentationCommandHandler
    : IRequestHandler<UpdatePresentationCommand, bool>
{
    private readonly IGenericRepository<PresentationEntity> _repository;

    public UpdatePresentationCommandHandler(
        IGenericRepository<PresentationEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdatePresentationCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (PresentationEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}