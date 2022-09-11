namespace EMA.Domain.Interfaces.Services;

public interface IEventsService
{
    public Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<EventEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task<Option<EventEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default,
        params Expression<Func<EventEntity, object>>[] includeProperties);

    public Task CreateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}