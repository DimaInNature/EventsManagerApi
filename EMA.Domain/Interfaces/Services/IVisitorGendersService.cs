namespace EMA.Domain.Interfaces.Services;

public interface IVisitorGendersService
{
    public Task<IEnumerable<VisitorGenderEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<Option<VisitorGenderEntity>> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public Task CreateAsync(VisitorGenderEntity entity,
        CancellationToken cancellationToken = default);

    public Task UpdateAsync(VisitorGenderEntity entity,
        CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}