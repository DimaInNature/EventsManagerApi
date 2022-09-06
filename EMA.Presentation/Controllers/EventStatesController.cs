namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class EventStatesController : ControllerBase
{
    /// <summary>
    /// Get all event states.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /EventStates
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Event states")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventEntity>>> GetList(
        IEventStatesService eventStatesService,
        CancellationToken cancellationToken)
    {
        var eventStates = await eventStatesService.GetAllAsync(cancellationToken);

        return eventStates.Any() ? Ok(value: eventStates) : NotFound();
    }

    /// <summary>
    /// Get event state by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /EventStates/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="eventStateService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Event states")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IEventStatesService eventStateService,
        CancellationToken cancellationToken)
    {
        var eventState = await eventStateService.GetAsync(id, cancellationToken);

        return eventState.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Create event state.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /EventStates
    ///     {
    ///         "name": "Finished"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Event states")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<EventStateEntity>> Create(
        [FromBody] EventStateEntity eventState,
        IEventStatesService eventStatesService,
        CancellationToken cancellationToken)
    {
        await eventStatesService.CreateAsync(entity: eventState, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = eventState?.Id },
            value: eventState);
    }

    /// <summary>
    /// Update event state.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /EventStates
    ///     {
    ///         "id": Guid,
    ///         "name": "Finished"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Event states")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] EventStateEntity eventState,
        IEventStatesService eventStatesService,
        CancellationToken cancellationToken)
    {
        await eventStatesService.UpdateAsync(entity: eventState, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete event state by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /EventStates/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Event states")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IEventStatesService eventStatesService,
        CancellationToken cancellationToken)
    {
        await eventStatesService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}