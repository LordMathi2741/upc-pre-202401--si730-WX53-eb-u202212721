using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using si730ebu202212721.API.Observability.Domain.Services;
using si730ebu202212721.API.Observability.Interfaces.REST.Resources;
using si730ebu202212721.API.Observability.Interfaces.REST.Transform;

namespace si730ebu202212721.API.Observability.Interfaces;

/// <summary>
///  Controller for managing the state of a thing.
/// </summary>
/// <param name="thingCommandService"></param>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///   - Version: 1.0.0
/// </remarks>
[ApiController]
[Route("/api/v1/[controller]")]
[AllowAnonymous]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(201)]
[ProducesResponseType(400)]
[ProducesResponseType(404)]
[ProducesResponseType(500)]
public class ThingStatesController(IThingStateCommandService thingStateCommandService) : ControllerBase
{
    /// <summary>
    ///  Creates a new thing state.
    /// </summary>
    /// <param name="createThingStateResource"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateThingState([FromBody] CreateThingStateResource createThingStateResource)
    {
        var command = CreateThingStateCommandFromResourceAssembler.ToCommandFromResource(createThingStateResource);
        var thingState = await thingStateCommandService.Handle(command);
        var thingStateResource = ThingStateResourceFromEntityAssembler.ToResourceFromEntity(thingState);
        return StatusCode(201, thingStateResource);
    }
}