using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;
using si730ebu202212721.API.Inventory.Interfaces.ACL;
using si730ebu202212721.API.Observability.Domain.Model.Exceptions;
using si730ebu202212721.API.Observability.Domain.Model.ValueObjects;

namespace si730ebu202212721.API.Observability.Application.Internal.OutboundServices.ACL;

/// ExternalThingService
/// <summary>
///    - This class is responsible for handling the external thing service.
///    - It is used to interact with the external thing service.
/// </summary>
/// <param name="thingContextFacade"></param>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///   - Version: 1.0.0
/// </remarks>
public class ExternalThingService(IThingContextFacade thingContextFacade)
{
    public async Task<ThingId?> FetchThingIdBySerialNumber(string serialNumber)
    {
        var thingId = await thingContextFacade.FetchThingIdBySerialNumber(serialNumber);
        if (thingId == 0) throw new ThingSerialNumberDoesntExistsException(serialNumber);
        return new ThingId(thingId);
    }

    public async Task<Thing> UpdateThingOperationMode(int id, int operationMode)
    {
        var thing = await thingContextFacade.UpdateThingCurrentOperation(id, operationMode);
        if (thing == null) throw new Exception("Error updating thing operation mode");
        return thing;
    }
}