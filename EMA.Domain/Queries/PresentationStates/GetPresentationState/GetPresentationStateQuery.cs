namespace EMA.Domain.Queries.PresentationStates;

public sealed record GetPresentationStateQuery
    : IRequest<Option<PresentationStateEntity>>
{
    public Option<Func<PresentationStateEntity, bool>> Predicate { get; }

    public GetPresentationStateQuery(
        Func<PresentationStateEntity, bool> predicate) =>
        Predicate = predicate;

    public GetPresentationStateQuery() { }
}