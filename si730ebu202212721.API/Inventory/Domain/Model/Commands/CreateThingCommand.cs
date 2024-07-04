using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebu202212721.API.Inventory.Domain.Model.Commands;

public record CreateThingCommand(string Model, decimal MaximumTemperatureThreshold, decimal MinimumHumidityThreshold);