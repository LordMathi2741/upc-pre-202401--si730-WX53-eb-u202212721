using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Shared.Domain.Repositories;

namespace si730ebu202212721.API.Inventory.Domain.Repositories;

public interface IThingRepository : IBaseRepository<Thing>
{
    bool ExistsBySerialNumber(string serialNumber);
    Task<Thing?> FindBySerialNumber(string serialNumber);
}