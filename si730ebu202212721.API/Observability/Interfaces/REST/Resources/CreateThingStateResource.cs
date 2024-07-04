namespace si730ebu202212721.API.Observability.Interfaces.REST.Resources;

public record CreateThingStateResource(string ThingSerialNumber, decimal CurrentHumidity, decimal CurrentTemperature, int CurrentOperationMode, DateTime CollectedAt);