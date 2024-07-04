using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Domain.Repositories;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202212721.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202212721.API.Observability.Infrastructure.Persistence.EFC.Repositories;

/// ThingStateRepository
/// <summary>
///   - Implements the IThingStateRepository interface
///   - Inherits from the BaseRepository<ThingState> class
///   - Make queries to the database
/// </summary>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///   -Version: 1.0.0
/// </remarks>
/// <param name="context"></param>
public class ThingStateRepository(AppDbContext context) : BaseRepository<ThingState>(context),IThingStateRepository
{
    public bool ExistsByThingSerialNumberAndCollectedAt(string thingSerialNumber, DateTime collectedAt)
    {
        return context.Set<ThingState>().AsEnumerable().Any(thing => thing.ThingSerialNumber == thingSerialNumber && thing.CollectedAt == collectedAt);
    }
}