using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.Queries;
using si730ebu202212721.API.Inventory.Domain.Repositories;
using si730ebu202212721.API.Inventory.Domain.Services;

namespace si730ebu202212721.API.Inventory.Application.Internal.QueryServices;

public class ThingQueryService(IThingRepository thingRepository) : IThingQueryService
{
    public async Task<Thing?> Handle(GetThingBySerialNumberQuery query)
    {
        return await thingRepository.FindBySerialNumber(query.SerialNumber);
    }

    public async Task<Thing?> Handle(GetThingByIdQuery query)
    {
        return await thingRepository.FindByIdAsync(query.Id);
    }
}