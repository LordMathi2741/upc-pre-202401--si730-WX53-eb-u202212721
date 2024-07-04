namespace si730ebu202212721.API.Inventory.Interfaces.REST.Resources;

public record CreateThingResource(string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);