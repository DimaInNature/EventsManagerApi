namespace EMA.Domain.Commands.VisitorContacts;

public sealed record CreateVisitorContactCommandHandler
    : IRequestHandler<CreateVisitorContactCommand, bool>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public CreateVisitorContactCommandHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorContactCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorContactEntity entity) =>
                await _repository.CreateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}