namespace EMA.Domain.Queries.PresentationStates;

public sealed record GetPresentationStatesListQuery
    : IRequest<IEnumerable<PresentationStateEntity>>
{
    public Option<Func<PresentationStateEntity, bool>> Predicate { get; }

    public GetPresentationStatesListQuery(
        Func<PresentationStateEntity, bool> predicate) =>
        Predicate = predicate;

    public GetPresentationStatesListQuery() { }
}