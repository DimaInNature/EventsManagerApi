namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class EventsController : ControllerBase
{
    /// <summary>
    /// Get all events.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Events
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventEntity>>> GetList(
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var events = await eventsService.GetAllAsync(cancellationToken);

        return events.Any() ? Ok(value: events) : NotFound();
    }

    /// <summary>
    /// Get event by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Events/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="eventsService"> Injected service </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var @event = await eventsService.GetAsync(id, cancellationToken);

        return @event.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Get event state by event Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Events/Guid/State
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="eventsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/State")]
    public async Task<IActionResult> GetState(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var @event = await eventsService.GetAsync(id, cancellationToken, includes: x => x.State);

        return @event.Select(x => x.State).Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Get event members by event Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Events/Guid/Members
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="eventsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/Members")]
    public async Task<IActionResult> GetMembers(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var eventMembers = await eventsService.GetAsync(id, cancellationToken, includes: x => x.Members);

        return eventMembers.Select(x => x.Members).Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Get event by Id with Includes
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Events/Guid/AllIncludes
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="eventsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/AllIncludes")]
    public async Task<IActionResult> GetWithAllIncludes(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        var @event = await eventsService.GetAsync(id, cancellationToken, x => x.Members, x => x.State);

        return @event.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Create event.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Events
    ///     {
    ///         "name": "DotNext",
    ///         "description": "Event for .Net developers.",
    ///         "Date": Date,
    ///         "Time": Time
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<EventEntity>> Create(
        [FromBody] EventEntity @event,
        IEventsService eventsService, 
        CancellationToken cancellationToken)
    {
        await eventsService.CreateAsync(entity: @event, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = @event?.Id },
            value: @event);
    }

    /// <summary>
    /// Update event.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Events
    ///     {
    ///         "id": Guid,
    ///         "name": "DotNext",
    ///         "description": "Event for .Net developers.",
    ///         "Date": Date,
    ///         "Time": Time
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] EventEntity @event,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        await eventsService.UpdateAsync(entity: @event, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete event by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Events/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Events")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IEventsService eventsService,
        CancellationToken cancellationToken)
    {
        await eventsService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}