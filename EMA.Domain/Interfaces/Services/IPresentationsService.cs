namespace EMA.Domain.Interfaces.Services;

public interface IEventsService
{
    public Task<IEnumerable<EventEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<EventEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task CreateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(EventEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}