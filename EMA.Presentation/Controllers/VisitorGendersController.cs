namespace EMA.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class VisitorGendersController : ControllerBase
{
    /// <summary>
    /// Get all visitor genders.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorGenders
    ///
    /// </remarks>
    /// <response code="200">List.</response>
    /// <response code="404">If not found.</response>
    [Tags(tags: "Visitor genders")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorGenderEntity>>> GetList(
        IVisitorGendersService visitorGenderService,
        CancellationToken cancellationToken)
    {
        var visitorGenders = await visitorGenderService.GetAllAsync(cancellationToken);

        return visitorGenders.Any() ? Ok(value: visitorGenders) : NotFound();
    }

    /// <summary>
    /// Get visitor gender by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /VisitorGenders/Guid
    ///
    /// </remarks>
    /// <param name="id"> Id. </param>
    /// <param name="visitorGendersService"> Injected service. </param>
    /// <param name="cancellationToken"> Cancellation token. </param>
    /// <response code="200"> Object. </response>
    /// <response code="404"> If not found. </response>
    [Tags(tags: "Visitor genders")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<IActionResult> Get(Guid id,
        IVisitorGendersService visitorGendersService,
        CancellationToken cancellationToken)
    {
        var visitorGender = await visitorGendersService.GetAsync(id, cancellationToken);

        return visitorGender.Match<IActionResult>(Some: Ok, None: NotFound);
    }

    /// <summary>
    /// Create visitor gender.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /VisitorGenders
    ///     {
    ///         "name": "Man"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Visitor genders")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [HttpPost]
    public async Task<ActionResult<VisitorGenderEntity>> Create(
        [FromBody] VisitorGenderEntity visitorGender,
        IVisitorGendersService visitorGenderService,
        CancellationToken cancellationToken)
    {
        await visitorGenderService.CreateAsync(entity: visitorGender, cancellationToken);

        return CreatedAtAction(
            actionName: nameof(Get),
            routeValues: new { id = visitorGender?.Id },
            value: visitorGender);
    }

    /// <summary>
    /// Update visitor gender.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /VisitorGenders
    ///     {
    ///         "id": Guid,
    ///         "name": "Man"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Visitor genders")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] VisitorGenderEntity visitorGender,
        IVisitorGendersService visitorGendersService,
        CancellationToken cancellationToken)
    {
        await visitorGendersService.UpdateAsync(entity: visitorGender, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete visitor gender by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /VisitorGenders/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Visitor genders")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(Guid id,
        IVisitorGendersService visitorGendersService,
        CancellationToken cancellationToken)
    {
        await visitorGendersService.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}