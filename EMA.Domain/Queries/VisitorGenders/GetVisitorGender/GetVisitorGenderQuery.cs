namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGenderQuery
    : IRequest<Option<VisitorGenderEntity>>
{
    public Option<Func<VisitorGenderEntity, bool>> Predicate { get; }

    public GetVisitorGenderQuery(
        Func<VisitorGenderEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorGenderQuery() { }
}