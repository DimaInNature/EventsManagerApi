namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationsListQuery
    : IRequest<IEnumerable<PresentationEntity>>
{
    public Option<Func<PresentationEntity, bool>> Predicate { get; }

    public GetPresentationsListQuery(
        Func<PresentationEntity, bool> predicate) =>
        Predicate = predicate;

    public GetPresentationsListQuery() { }
}