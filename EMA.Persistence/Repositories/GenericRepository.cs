namespace EMA.Persistence.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    private readonly DbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context) =>
        (_context, _dbSet) = (context, _dbSet = context.Set<TEntity>());

    public TEntity? GetFirstOrDefault(Func<TEntity, bool> predicate) =>
        _dbSet.AsNoTracking().FirstOrDefault(predicate);

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Guid key, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking()
        .FirstOrDefaultAsync(predicate: entity => entity.Id.Equals(key),
            cancellationToken);

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        await _dbSet.AsNoTracking()
        .FirstOrDefaultAsync(predicate, cancellationToken);

    public TEntity? GetFirstOrDefaultWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties) =>
         IncludeWithNoTracking(includeProperties).FirstOrDefault(predicate);

    public IEnumerable<TEntity> GetAll() => _dbSet.AsNoTracking();

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate) =>
        _dbSet.AsNoTracking().Where(predicate);

    public IEnumerable<TEntity> GetAllWithInclude(
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        IncludeWithNoTracking(includeProperties);

    public IEnumerable<TEntity> GetAllWithInclude(
        Func<TEntity, bool> predicate,
        params Expression<Func<TEntity, object>>[] includeProperties) =>
        IncludeWithNoTracking(includeProperties).Where(predicate);

    public async Task<bool> CreateAsync(TEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity is default(TEntity) or null)
        {
            return false;
        }

        await _dbSet.AddAsync(entity, cancellationToken);

        return await _context.SaveChangesAsync(cancellationToken) is 1;
    }

    public async Task<bool> UpdateAsync(TEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity is default(TEntity) or null)
        {
            return false;
        }

        _dbSet.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;

        return await _context.SaveChangesAsync(cancellationToken) is 1;
    }

    public async Task<bool> DeleteAsync(Guid key, CancellationToken cancellationToken = default)
    {
        if (key.Equals(g: default))
        {
            return false;
        }

        TEntity? entity = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(predicate: entity => entity.Id.Equals(key),
            cancellationToken);

        if (entity is default(TEntity) or null)
        {
            return false;
        }

        _dbSet.Remove(entity);

        return await _context.SaveChangesAsync(cancellationToken: cancellationToken) is 1;
    }

    public async Task<bool> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        if (entities is null || entities.Any() is false)
        {
            return false;
        }

        _dbSet.RemoveRange(entities);

        return await _context.SaveChangesAsync(cancellationToken: cancellationToken) == entities.Count();
    }

    private IEnumerable<TEntity> IncludeWithNoTracking(
         params Expression<Func<TEntity, object>>[] _includeProperties) =>
         _includeProperties.Aggregate(
             seed: _dbSet.AsNoTracking(),
             func: (current, includeProperty) =>
             current.Include(includeProperty));
}