namespace EMA.Domain.Interfaces.Services;

public interface IVisitorContactsService
{
    public Task<IEnumerable<VisitorContactEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<VisitorContactEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task CreateAsync(VisitorContactEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(VisitorContactEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}