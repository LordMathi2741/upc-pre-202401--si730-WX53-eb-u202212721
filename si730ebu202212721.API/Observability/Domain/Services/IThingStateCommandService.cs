using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Domain.Model.Commands;

namespace si730ebu202212721.API.Observability.Domain.Services;

/// IThingStateCommandService
/// <summary>
///   - Service for handling commands related to ThingState
///   - This service is responsible for handling commands related to ThingState
/// </summary>
/// <remarks>
///    - Author: U202212721 Mathias Jave Diaz
///    - Version: 1.0.0
/// </remarks>
public interface IThingStateCommandService
{
    Task<ThingState?> Handle(CreateThingStateCommand command);
}