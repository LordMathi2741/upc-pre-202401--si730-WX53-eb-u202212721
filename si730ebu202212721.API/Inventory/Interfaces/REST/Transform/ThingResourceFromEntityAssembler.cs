using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202212721.API.Inventory.Interfaces.REST.Transform;

public class ThingResourceFromEntityAssembler
{
    public static ThingResource ToResourceFromEntity(Thing thing)
    {
        return new ThingResource(thing.Id, thing.Model, thing.MaximumTemperatureThreshold,
            thing.MinimumHumidityThreshold,thing.OperationMode.ToString(),thing.SerialNumber);
    }
}