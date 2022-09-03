namespace EMA.Domain.Commands.Visitors.CreateVisitor;

public sealed record CreateVisitorCommandHandler
    : IRequestHandler<CreateVisitorCommand, bool>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public CreateVisitorCommandHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}