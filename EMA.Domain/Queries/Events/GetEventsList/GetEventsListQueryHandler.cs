namespace EMA.Domain.Queries.Events;

public sealed record GetEventsListQueryHandler
    : IRequestHandler<GetEventsListQuery, IEnumerable<EventEntity>>
{
    private readonly IGenericRepository<EventEntity> _repository;

    public GetEventsListQueryHandler(
        IGenericRepository<EventEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<EventEntity>> Handle(
        GetEventsListQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.IncludeProperties is null)
            return await Task.FromResult(
                result: _repository.GetAll());

        return await Task.FromResult(
            result: _repository.GetAllWithInclude(
                includeProperties: request.IncludeProperties));
    }
}