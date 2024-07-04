using si730ebu202212721.API.Inventory.Domain.Model.Commands;
using si730ebu202212721.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202212721.API.Inventory.Interfaces.REST.Transform;

public class CreateThingCommandFromResourceAssembler
{
    public static CreateThingCommand ToCommandFromResource(CreateThingResource resource)
    {
        return new CreateThingCommand(resource.Model, resource.MaximumTemperatureThreshold,
            resource.MinimumHumidityThreshold);
    }
    
}