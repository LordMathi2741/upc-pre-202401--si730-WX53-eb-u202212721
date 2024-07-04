
using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.Queries;
using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;
using si730ebu202212721.API.Inventory.Domain.Repositories;
using si730ebu202212721.API.Inventory.Domain.Services;

namespace si730ebu202212721.API.Inventory.Interfaces.ACL.Services;

/// <summary>
///   - This class is used to implement the IThingContextFacade interface.
///   - This class is used to implement the thing services for use in other services
/// </summary>
/// <remarks>
///   - Author: U2022212721 Mathias Jave Diaz
///    - Version: 1.0.0
/// </remarks>
/// <param name="thingRepository"></param>
public class ThingContextFacade(IThingQueryService thingQueryService) : IThingContextFacade
{
    public async Task<int> FetchThingIdBySerialNumber(string serialNumber)
    {
        var query = new GetThingBySerialNumberQuery(serialNumber);
        var thing = await thingQueryService.Handle(query);
        return thing?.Id ?? 0;
    }

    public async Task<Thing?> UpdateThingCurrentOperation(int id,int operationMode)
    {
        var query = new GetThingByIdQuery(id);
        var thing = await thingQueryService.Handle(query);
        if (thing != null)
        {
            if (Enum.IsDefined(typeof(EOperationMode), operationMode))
            {
                thing.OperationMode = (EOperationMode)operationMode;
                thing.UpdatedDate = DateTime.UtcNow;
            }
            else
            {
                throw new ArgumentException($"Invalid operation mode: {operationMode}");
            }
        }
        return thing;
    }
}