namespace EMA.Domain.Interfaces.Services;

public interface IVisitorContactsService
{
    public Task<IEnumerable<VisitorContactEntity>> GetAllAsync();

    public Task<Option<VisitorContactEntity>> GetAsync(Guid id);

    public Task CreateAsync(VisitorContactEntity entity);

    public Task UpdateAsync(VisitorContactEntity entity);

    public Task DeleteAsync(Guid id);
}