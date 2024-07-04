
using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Interfaces.REST.Resources;

namespace si730ebu202212721.API.Observability.Interfaces.REST.Transform;

public class ThingStateResourceFromEntityAssembler
{
    public static ThingStateResource ToResourceFromEntity(ThingState thingState)
    {
        return new ThingStateResource(thingState.Id, thingState.ThingSerialNumber,
        thingState.CurrentHumidity,thingState.CurrentTemperature,thingState.CurrentOperationMode,
        thingState.CollectedAt,thingState.ThingId);
    }
}