namespace EMA.Domain.Interfaces.Services;

public interface IVisitorCredentialsService
{
    public Task<IEnumerable<VisitorCredentialEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public Task<VisitorCredentialEntity?> GetAsync(Guid id,
         CancellationToken cancellationToken = default);

    public Task CreateAsync(VisitorCredentialEntity entity,
         CancellationToken cancellationToken = default);

    public Task UpdateAsync(VisitorCredentialEntity entity,
         CancellationToken cancellationToken = default);

    public Task DeleteAsync(Guid id,
         CancellationToken cancellationToken = default);
}