using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebu202212721.API.Inventory.Interfaces.ACL;

/// IThingContextFacade
/// <summary>
///   - This interface is used to define the contract for the ThingContextFacade.
///   - This interface is used to export the thing services for use in other services
///   - Follow the facade pattern
/// </summary>
/// <remarks>
///   - Author: U2022212721 Mathias Jave Diaz
///   - Version: 1.0.0
/// </remarks>
public interface IThingContextFacade
{
    

    Task<int> FetchThingIdBySerialNumber(string serialNumber);
    Task<Thing?> UpdateThingCurrentOperation(int id, int operationMode);
}