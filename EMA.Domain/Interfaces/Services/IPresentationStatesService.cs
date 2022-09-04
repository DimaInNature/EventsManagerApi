namespace EMA.Domain.Interfaces.Services;

public interface IPresentationStatesService
{
    public Task<IEnumerable<PresentationStateEntity>> GetAllAsync(
        CancellationToken cancellationToken);

    public Task<Option<PresentationStateEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken);

    public Task CreateAsync(PresentationStateEntity entity,
        CancellationToken cancellationToken);

    public Task UpdateAsync(PresentationStateEntity entity,
        CancellationToken cancellationToken);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken);
}