namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class ReportsController : ControllerBase
{
    /// <summary>
    /// Get members count by event id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Reports/Events/GUID/Members/Count
    ///
    /// </remarks>
    /// <response code="200">Members count.</response>
    [Tags(tags: "Reports")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [HttpGet(template: "Events/{id}/Members/Count")]
    public async Task<ActionResult<int>> GetMembersCountByEventId(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var @event = await eventsService.GetAsync(id, cancellationToken,
            includeProperties: @event => @event.Members!);

        var eventMembers = @event?.Members;

        int membersCount = eventMembers?.Count() ?? 0;

        return membersCount;
    }

    /// <summary>
    /// Get members count.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Reports/Events/Members/Count
    ///
    /// </remarks>
    /// <response code="200">Members count.</response>
    [Tags(tags: "Reports")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [HttpGet(template: "Events/Members/Count")]
    public async Task<ActionResult<int>> GetMembersCount(
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var events = await eventsService.GetAllAsync(cancellationToken,
            includeProperties: @event => @event.Members!);

        var members = events.Select(selector: @event => @event.Members)
            .DistinctBy(keySelector: @event => @event?
                .Select(selector: @event => @event.Id))
            .AsEnumerable();

        int membersCount = members.Count();

        return membersCount;
    }
}