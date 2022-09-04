namespace EMA.Domain.Interfaces.Services;

public interface IVisitorCredentialsService
{
    public Task<IEnumerable<VisitorCredentialEntity>> GetAllAsync();

    public Task<Option<VisitorCredentialEntity>> GetAsync(Guid id);

    public Task CreateAsync(VisitorCredentialEntity entity);

    public Task UpdateAsync(VisitorCredentialEntity entity);

    public Task DeleteAsync(Guid id);
}