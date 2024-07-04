namespace si730ebu202212721.API.Observability.Domain.Model.Commands;

// CreateThingStateCommand
/// <summary>
///    - Command to create a new ThingState
///    - The command is used to create a new ThingState
/// </summary>
/// <param name="ThingSerialNumber"></param>
/// <param name="CurrentHumidity"></param>
/// <param name="CurrentTemperature"></param>
/// <param name="CurrentOperationMode"></param>
/// <param name="CollectedAt"></param>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///   - Version 1.0.0
/// </remarks>
public record CreateThingStateCommand(string ThingSerialNumber, decimal CurrentHumidity, decimal CurrentTemperature, int CurrentOperationMode, DateTime CollectedAt);