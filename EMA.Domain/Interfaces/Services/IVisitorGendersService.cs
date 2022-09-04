namespace EMA.Domain.Interfaces.Services;

public interface IVisitorGendersService
{
    public Task<IEnumerable<VisitorGenderEntity>> GetAllAsync();

    public Task<Option<VisitorGenderEntity>> GetAsync(Guid id);

    public Task CreateAsync(VisitorGenderEntity entity);

    public Task UpdateAsync(VisitorGenderEntity entity);

    public Task DeleteAsync(Guid id);
}