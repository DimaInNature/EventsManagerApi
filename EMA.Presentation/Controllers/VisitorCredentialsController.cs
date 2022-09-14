namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VisitorCredentialsController : ControllerBase
{
    /// <summary>
    /// Get all visitor credential.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorCredentials
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Visitor credentials")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorCredentialEntity>>> GetList(
        IVisitorCredentialsService visitorCredentialsService,
        CancellationToken cancellationToken)
    {
        var visitorCredentials = await visitorCredentialsService.GetAllAsync(cancellationToken);

        return visitorCredentials.Any() ? Ok(value: visitorCredentials) : NotFound();
    }

    /// <summary>
    /// Get visitor credential by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorCredentials/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorCredentialsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitor credentials")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IVisitorCredentialsService visitorCredentialsService,
        CancellationToken cancellationToken)
    {
        var eventState = await visitorCredentialsService.GetAsync(id, cancellationToken);

        return eventState is not null ? Ok(value: eventState) : NotFound();
    }

    /// <summary>
    /// Create visitor credential.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VisitorCredentials
    ///     {
    ///         "name": "John",
    ///         "lastName": "Doe",
    ///         "patronymic": "None",
    ///         "birthDay": datetime
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Visitor credentials")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VisitorCredentialEntity>> Create(
        [FromBody] VisitorCredentialEntity visitorCredential,
        IVisitorCredentialsService visitorCredentialsService,
        CancellationToken cancellationToken)
    {
        await visitorCredentialsService.CreateAsync(entity: visitorCredential, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = visitorCredential?.Id },
            value: visitorCredential);
    }

    /// <summary>
    /// Update visitor credential.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VisitorCredentials
    ///     {
    ///         "id": Guid,
    ///         "name": "John",
    ///         "lastName": "Doe",
    ///         "patronymic": "None",
    ///         "birthDay": datetime
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Visitor credentials")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VisitorCredentialEntity visitorCredential,
        IVisitorCredentialsService visitorCredentialsService,
        CancellationToken cancellationToken)
    {
        await visitorCredentialsService.UpdateAsync(entity: visitorCredential, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete visitor credential by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VisitorCredentials/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Visitor credentials")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IVisitorCredentialsService visitorCredentialsService,
        CancellationToken cancellationToken)
    {
        await visitorCredentialsService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}