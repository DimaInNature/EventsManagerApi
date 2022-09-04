namespace EMA.Domain.Interfaces.Services;

public interface IPresentationsService
{
    public Task<IEnumerable<PresentationEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<PresentationEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task CreateAsync(PresentationEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(PresentationEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}