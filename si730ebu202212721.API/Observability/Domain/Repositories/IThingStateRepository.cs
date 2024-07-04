using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Shared.Domain.Repositories;

namespace si730ebu202212721.API.Observability.Domain.Repositories;

/// IThingStateRepository
/// <summary>
///   - Interface for the ThingState repository
///   - Inherits from IBaseRepository<ThingState>
///   - Provides the contract for the ThingState repository
///   - Follow the repository pattern and open close principle
/// </summary>
/// <remarks>
///    - Author: U202212721 Mathias Jave Diaz
///    - Version: 1.0.0
/// </remarks>
/// 
public interface IThingStateRepository : IBaseRepository<ThingState>
{
    bool ExistsByThingSerialNumberAndCollectedAt(string thingSerialNumber,DateTime collectedAt);
}