using si730ebu202212721.API.Observability.Application.Internal.OutboundServices.ACL;
using si730ebu202212721.API.Observability.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Domain.Model.Commands;
using si730ebu202212721.API.Observability.Domain.Model.Exceptions;
using si730ebu202212721.API.Observability.Domain.Repositories;
using si730ebu202212721.API.Observability.Domain.Services;
using si730ebu202212721.API.Shared.Domain.Repositories;

namespace si730ebu202212721.API.Observability.Application.Internal.CommandServices;

/// ThingStateCommandService
/// <summary>
///  - This class is responsible for handling the commands related to the ThingState aggregate root
///   - It validates the command and then creates a new ThingState entity and saves it to the database.
///   - It also checks if the ThingSerialNumber exists in the external service and if the ThingState with the same ThingSerialNumber and CollectedAt already exists in the database.
/// </summary>
/// <param name="unitOfWork"></param>
/// <param name="thingStateRepository"></param>
/// <param name="externalThingService"></param>
///
/// <remarks>
///   -Author: U202212721 Mathias Jave Diaz
///   -Version 1.0.0
/// </remarks>
public class ThingStateCommandService(IUnitOfWork unitOfWork, IThingStateRepository thingStateRepository, ExternalThingService externalThingService) : IThingStateCommandService
{
    public async Task<ThingState?> Handle(CreateThingStateCommand command)
    {
        var thingId = await externalThingService.FetchThingIdBySerialNumber(command.ThingSerialNumber);

        if (thingId == null)
        {
            throw new ThingSerialNumberDoesntExistsException(command.ThingSerialNumber);
        }
        if (thingStateRepository.ExistsByThingSerialNumberAndCollectedAt(command.ThingSerialNumber,command.CollectedAt))
        {
            throw new ThingStateWithThisThingSerialNumberAndCollectedAtAlreadyExistsException(command.ThingSerialNumber,
                command.CollectedAt);
        }

        if (command.CollectedAt > DateTime.Now)
        {
            throw new CollectedAtCannotBeInTheFutureException(command.CollectedAt);
        }

        if (command.CurrentOperationMode < 0 || command.CurrentOperationMode > 2)
        {
            throw new InvalidCurrentOperationModeException(command.CurrentOperationMode);
        }
        
        var thingState = new ThingState(command);
        thingState.ThingId = thingId.Id;
        await thingStateRepository.AddAsync(thingState);
        await unitOfWork.CompleteAsync();
        return thingState;
    }
}