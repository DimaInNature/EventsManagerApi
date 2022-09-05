namespace EMA.Domain.Interfaces.Services;

public interface IEventStatesService
{
    public Task<IEnumerable<EventStateEntity>> GetAllAsync(
        CancellationToken cancellationToken);

    public Task<Option<EventStateEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken);

    public Task CreateAsync(EventStateEntity entity,
        CancellationToken cancellationToken);

    public Task UpdateAsync(EventStateEntity entity,
        CancellationToken cancellationToken);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken);
}