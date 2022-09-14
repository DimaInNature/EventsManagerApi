namespace EMA.Domain.Queries.VisitorGenders;

public sealed record GetVisitorGenderQuery
    : IRequest<VisitorGenderEntity?>
{
    public Func<VisitorGenderEntity, bool>? Predicate { get; }

    public GetVisitorGenderQuery(
        Func<VisitorGenderEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVisitorGenderQuery() { }
}