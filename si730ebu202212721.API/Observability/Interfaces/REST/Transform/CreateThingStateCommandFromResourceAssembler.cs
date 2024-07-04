using si730ebu202212721.API.Inventory.Interfaces.REST.Resources;
using si730ebu202212721.API.Observability.Domain.Model.Commands;
using si730ebu202212721.API.Observability.Interfaces.REST.Resources;

namespace si730ebu202212721.API.Observability.Interfaces.REST.Transform;

public class CreateThingStateCommandFromResourceAssembler
{
    public static CreateThingStateCommand ToCommandFromResource(CreateThingStateResource resource)
    {
        return new CreateThingStateCommand(resource.ThingSerialNumber, resource.CurrentHumidity,
            resource.CurrentTemperature,resource.CurrentOperationMode,resource.CollectedAt);
    }
}