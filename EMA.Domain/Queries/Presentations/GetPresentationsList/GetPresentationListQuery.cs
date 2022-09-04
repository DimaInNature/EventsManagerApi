namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationListQuery
    : IRequest<IEnumerable<PresentationEntity>>
{
    public Option<Func<PresentationEntity, bool>> Predicate { get; }

    public GetPresentationListQuery(
        Func<PresentationEntity, bool> predicate) =>
        Predicate = predicate;

    public GetPresentationListQuery() { }
}