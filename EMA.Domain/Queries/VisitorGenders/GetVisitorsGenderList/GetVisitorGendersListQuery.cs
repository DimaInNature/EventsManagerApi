namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGendersListQuery
    : IRequest<IEnumerable<VisitorGenderEntity>>
{
    public Func<VisitorGenderEntity, bool>? Predicate { get; }

    public GetVisitorGendersListQuery(
        Func<VisitorGenderEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorGendersListQuery() { }
}