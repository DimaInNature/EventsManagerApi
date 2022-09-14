namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGendersListQueryHandler
    : IRequestHandler<GetVisitorGendersListQuery, IEnumerable<VisitorGenderEntity>>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public GetVisitorGendersListQueryHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VisitorGenderEntity>> Handle(
        GetVisitorGendersListQuery request,
        CancellationToken cancellationToken = default)
    {
        if (request.Predicate is null)
        {
            return await Task.FromResult(result: _repository.GetAll());
        }

        return await Task.FromResult(
            result: _repository.GetAll(
                predicate: request.Predicate));
    }
}