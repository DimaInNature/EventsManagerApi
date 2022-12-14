namespace EMA.Domain.Interfaces.Services;

public interface IEventsService
{
    public Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<EventEntity, object>>[] includeProperties);

    public Task<EventEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task<EventEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default,
        params Expression<Func<EventEntity, object>>[] includeProperties);

    public Task CreateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(IEnumerable<EventEntity> entities,
        CancellationToken cancellationToken = default);
}