namespace EMA.Domain.Interfaces.Services;

public interface IPresentationStatesService
{
    public Task<IEnumerable<PresentationStateEntity>> GetAllAsync();

    public Task<Option<PresentationStateEntity>> GetAsync(Guid id);

    public Task CreateAsync(PresentationStateEntity entity);

    public Task UpdateAsync(PresentationStateEntity entity);

    public Task DeleteAsync(Guid id);
}