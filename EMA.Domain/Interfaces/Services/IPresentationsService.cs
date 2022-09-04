namespace EMA.Domain.Interfaces.Services;

public interface IPresentationsService
{
    public Task<IEnumerable<PresentationEntity>> GetAllAsync();

    public Task<Option<PresentationEntity>> GetAsync(Guid id);

    public Task CreateAsync(PresentationEntity entity);

    public Task UpdateAsync(PresentationEntity entity);

    public Task DeleteAsync(Guid id);
}