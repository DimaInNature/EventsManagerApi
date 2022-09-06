namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VisitorContactsController : ControllerBase
{
    /// <summary>
    /// Get all visitor contacts.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorContacts
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Visitor contacts")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorContactEntity>>> GetList(
        IVisitorContactsService visitorContactsService,
        CancellationToken cancellationToken)
    {
        var visitorContacts = await visitorContactsService.GetAllAsync(cancellationToken);

        return visitorContacts.Any() ? Ok(value: visitorContacts) : NotFound();
    }

    /// <summary>
    /// Get visitor contact by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorContacts/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorContactsService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitor contacts")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IVisitorContactsService visitorContactsService,
        CancellationToken cancellationToken)
    {
        var visitorContact = await visitorContactsService.GetAsync(id, cancellationToken);

        return visitorContact.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Create visitor contact.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VisitorContacts
    ///     {
    ///         "phone": "123-456-789",
    ///         "email": "example@bk.ru"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Visitor contacts")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VisitorContactEntity>> Create(
        [FromBody] VisitorContactEntity visitorContact,
        IVisitorContactsService visitorContactsService,
        CancellationToken cancellationToken)
    {
        await visitorContactsService.CreateAsync(entity: visitorContact, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = visitorContact?.Id },
            value: visitorContact);
    }

    /// <summary>
    /// Update visitor contact.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VisitorContacts
    ///     {
    ///         "id": Guid,
    ///         "phone": "123-456-789",
    ///         "email": "example@bk.ru"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Visitor contacts")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VisitorContactEntity visitorContact,
        IVisitorContactsService visitorContactsService,
        CancellationToken cancellationToken)
    {
        await visitorContactsService.UpdateAsync(entity: visitorContact, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete visitor contact by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VisitorContacts/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Visitor contacts")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IVisitorContactsService visitorContactsService,
        CancellationToken cancellationToken)
    {
        await visitorContactsService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}