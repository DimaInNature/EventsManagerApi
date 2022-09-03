namespace EMA.Domain.Commands.VisitorContacts;

public sealed record UpdateVisitorContactCommandHandler
    : IRequestHandler<UpdateVisitorContactCommand, bool>
{
    private readonly IGenericRepository<VisitorContactEntity> _repository;

    public UpdateVisitorContactCommandHandler(
        IGenericRepository<VisitorContactEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVisitorContactCommand request,
        CancellationToken cancellationToken = default) =>
        await request.Entity.MatchAsync(
            Some: async (VisitorContactEntity entity) =>
                await _repository.UpdateAsync(entity, cancellationToken),
            None: async () =>
                await Task.FromResult<bool>(result: default));
}