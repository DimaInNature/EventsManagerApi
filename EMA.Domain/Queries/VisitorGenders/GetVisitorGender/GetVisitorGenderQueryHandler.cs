namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGenderQueryHandler
    : IRequestHandler<GetVisitorGenderQuery, VisitorGenderEntity?>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public GetVisitorGenderQueryHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<VisitorGenderEntity?> Handle(
        GetVisitorGenderQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
        {
            return default;
        }

        return await Task.FromResult(
            result: _repository.GetFirstOrDefault(
                predicate: request.Predicate));
    }
}