namespace EMA.Domain.Interfaces.Services;

public interface IVisitorsService
{
    public Task<IEnumerable<VisitorEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<VisitorEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task<Option<VisitorEntity>> GetAsync(Guid id,
      CancellationToken cancellationToken = default,
      params Expression<Func<VisitorEntity, object>>[] includeProperties);

    public Task CreateAsync(VisitorEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(VisitorEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}