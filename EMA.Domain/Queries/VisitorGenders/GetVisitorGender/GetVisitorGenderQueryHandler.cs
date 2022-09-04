namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGenderQueryHandler
    : IRequestHandler<GetVisitorGenderQuery, Option<VisitorGenderEntity>>
{
    private readonly IGenericRepository<VisitorGenderEntity> _repository;

    public GetVisitorGenderQueryHandler(
        IGenericRepository<VisitorGenderEntity> repository) =>
        _repository = repository;

    public async Task<Option<VisitorGenderEntity>> Handle(
        GetVisitorGenderQuery request,
        CancellationToken cancellationToken = default) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}