namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VisitorsController : ControllerBase
{
    /// <summary>
    /// Get all visitors.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorEntity>>> GetList(
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitors = await visitorsService.GetAllAsync(cancellationToken);

        return visitors.Any() ? Ok(value: visitors) : NotFound();
    }

    /// <summary>
    /// Get visitor by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Get visitor contact by visitor Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid/Contact
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/Contact")]
    public async Task<IActionResult> GetContact(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken,
            includeProperties: visitor => visitor.Contact!);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Get visitor credentials by visitor Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid/Credentials
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/Credentials")]
    public async Task<IActionResult> GetCredentials(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken,
            includeProperties: visitor => visitor.Credentials!);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Get visitor event by visitor Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid/Event
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/Event")]
    public async Task<IActionResult> GetEvent(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken,
            includeProperties: visitor => visitor.Event!);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Get visitor gender by visitor Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid/Gender
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/Gender")]
    public async Task<IActionResult> GetGender(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken,
            includeProperties: visitor => visitor.Gender!);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Get visitor by Id with Includes
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Visitors/Guid/AllIncludes
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}/AllIncludes")]
    public async Task<IActionResult> GetWithAllIncludes(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        var visitor = await visitorsService.GetAsync(id, cancellationToken,
            visitor => visitor.Contact!,
            visitor => visitor.Credentials!,
            visitor => visitor.Event!,
            visitor => visitor.Gender!);

        return visitor is not null ? Ok(value: visitor) : NotFound();
    }

    /// <summary>
    /// Create visitor.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Visitors
    ///     {
    ///         "credentialsId": Guid,
    ///         "genderId": Guid,
    ///         "contactId": Guid,
    ///         "eventId": Guid
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VisitorEntity>> Create(
        [FromBody] VisitorEntity visitor,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        await visitorsService.CreateAsync(entity: visitor, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = visitor?.Id },
            value: visitor);
    }

    /// <summary>
    /// Update visitor.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Visitors
    ///     {
    ///         "id": Guid,
    ///         "credentialsId": Guid,
    ///         "genderId": Guid,
    ///         "contactId": Guid,
    ///         "eventId": Guid
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VisitorEntity visitor,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        await visitorsService.UpdateAsync(entity: visitor, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete visitor by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Visitors/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Visitors")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IVisitorsService visitorsService,
        CancellationToken cancellationToken)
    {
        await visitorsService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}