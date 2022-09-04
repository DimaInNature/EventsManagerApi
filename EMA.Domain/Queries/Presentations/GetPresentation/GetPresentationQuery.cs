namespace EMA.Domain.Queries.Presentations;

public sealed record GetPresentationQuery
    : IRequest<Option<PresentationEntity>>
{
    public Option<Func<PresentationEntity, bool>> Predicate { get; }

    public GetPresentationQuery(
        Func<PresentationEntity, bool> predicate) =>
        Predicate = predicate;

    public GetPresentationQuery() { }
}