namespace EMA.Domain.Commands.Visitors;

public sealed record UpdateVisitorCommandHandler
    : IRequestHandler<UpdateVisitorCommand, bool>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public UpdateVisitorCommandHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVisitorCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}