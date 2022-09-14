namespace EMA.Domain.Commands.Visitors;

public sealed record CreateVisitorCommandHandler
    : IRequestHandler<CreateVisitorCommand, bool>
{
    private readonly IGenericRepository<VisitorEntity> _repository;

    public CreateVisitorCommandHandler(
        IGenericRepository<VisitorEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVisitorCommand request,
        CancellationToken cancellationToken = default)
    {
        if (request.Entity is null)
        {
            return await Task.FromResult<bool>(result: default);
        }

        return await _repository.CreateAsync(
            entity: request.Entity, cancellationToken);
    }
}