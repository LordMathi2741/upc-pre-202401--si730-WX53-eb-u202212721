using Microsoft.EntityFrameworkCore;
using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Repositories;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202212721.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// ThingRepository
/// <summary>
///   - The implementation of IThingRepository.
///    - The repository is responsible for the CRUD operations of the Thing aggregate root
///    - Follow the repository pattern and Dependencies Inversion Principle
/// </summary>
/// <param name="context"></param>
/// <remarks>
///   Author: U202212721 Mathias Jave Diaz
///   Version: 1.0.0
/// </remarks>
public class ThingRepository(AppDbContext context) : BaseRepository<Thing>(context), IThingRepository
{
    public bool ExistsBySerialNumber(string serialNumber)
    {
        Guid serialNumberGuid = Guid.Parse(serialNumber);
        return context.Set<Thing>().AsEnumerable().Any(thing => thing.SerialNumberValueObject.Value == serialNumberGuid);
    }

    public async Task<Thing?> FindBySerialNumber(string serialNumber)
    {
        Guid serialNumberGuid = Guid.Parse(serialNumber);
        return await context.Set<Thing>().Where(thing => thing.SerialNumberValueObject.Value == serialNumberGuid).FirstOrDefaultAsync();
    }
}