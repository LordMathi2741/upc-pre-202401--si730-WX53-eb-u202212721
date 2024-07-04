using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.Queries;

namespace si730ebu202212721.API.Inventory.Domain.Services;

public interface IThingQueryService
{
    Task<Thing?> Handle(GetThingBySerialNumberQuery query);
    Task<Thing?> Handle(GetThingByIdQuery query);
}