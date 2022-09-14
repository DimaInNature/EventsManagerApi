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
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.UpdateAsync(
            entity: request.Entity, cancellationToken);
    }
}