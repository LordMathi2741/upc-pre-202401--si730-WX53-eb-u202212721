using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using si730ebu202212721.API.Inventory.Domain.Model.Queries;
using si730ebu202212721.API.Inventory.Domain.Services;
using si730ebu202212721.API.Inventory.Interfaces.REST.Resources;
using si730ebu202212721.API.Inventory.Interfaces.REST.Transform;

namespace si730ebu202212721.API.Inventory.Interfaces.REST;

// ThingsController
/// <summary>
///    - ThingsController is a REST API controller for managing things.
///    - It is the entry point for all requests related to Inventory bounded context
/// </summary>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///    -Version: 1.0.0
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(201)]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
public class ThingsController(IThingCommandService thingCommandService, IThingQueryService thingQueryService) : ControllerBase
{
    /// <summary>
    ///   CreateThing is a POST method that creates a new thing.
    /// </summary>
    /// <param name="createThingResource"></param>
    /// <response code="201">Returns the newly created thing</response>
    /// <response code="400"> Return bad request </response>
    /// <response code="500"> Return internal server error </response>
    [HttpPost]
    public async Task<IActionResult> CreateThing([FromBody] CreateThingResource createThingResource)
    {
        var command = CreateThingCommandFromResourceAssembler.ToCommandFromResource(createThingResource);
        var thing = await thingCommandService.Handle(command);
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return StatusCode(201, thingResource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetThingById(int id)
    {
        var query = new GetThingByIdQuery(id);
        var thing = await thingQueryService.Handle(query);
        var thingResource = ThingResourceFromEntityAssembler.ToResourceFromEntity(thing);
        return Ok(thingResource);
    }
}