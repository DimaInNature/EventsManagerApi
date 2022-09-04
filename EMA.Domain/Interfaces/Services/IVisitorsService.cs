namespace EMA.Domain.Interfaces.Services;

public interface IVisitorsService
{
    public Task<IEnumerable<VisitorEntity>> GetAllAsync();

    public Task<Option<VisitorEntity>> GetAsync(Guid id);

    public Task CreateAsync(VisitorEntity entity);

    public Task UpdateAsync(VisitorEntity entity);

    public Task DeleteAsync(Guid id);
}