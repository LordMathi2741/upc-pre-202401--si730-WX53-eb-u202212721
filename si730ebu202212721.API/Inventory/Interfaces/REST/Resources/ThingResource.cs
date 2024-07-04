namespace si730ebu202212721.API.Inventory.Interfaces.REST.Resources;

public record ThingResource(long Id,string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold,string OperationMode,string serialNumber);