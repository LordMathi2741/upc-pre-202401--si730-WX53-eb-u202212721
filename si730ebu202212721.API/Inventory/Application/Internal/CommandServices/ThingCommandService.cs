using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Inventory.Domain.Model.Commands;
using si730ebu202212721.API.Inventory.Domain.Model.Exceptions;
using si730ebu202212721.API.Inventory.Domain.Repositories;
using si730ebu202212721.API.Inventory.Domain.Services;
using si730ebu202212721.API.Shared.Domain.Repositories;

namespace si730ebu202212721.API.Inventory.Application.Internal.CommandServices;

public class ThingCommandService(IUnitOfWork unitOfWork, IThingRepository thingRepository) : IThingCommandService
{
    public async Task<Thing?> Handle(CreateThingCommand command)
    {
        if (command.MaximumTemperatureThreshold < -40.00m || command.MaximumTemperatureThreshold > 80.00m)
        {
            throw new InvalidMaximumTemperatureThresholdException(command.MaximumTemperatureThreshold);
        }

        if (command.MinimumHumidityThreshold < 0.00m || command.MinimumHumidityThreshold > 100.00m)
        {
            throw new InvalidMinimumHumidityThresholdException(command.MinimumHumidityThreshold);
        }
        var thing = new Thing(command);
        if (thingRepository.ExistsBySerialNumber(thing.SerialNumber))
        {
            throw new SerialNumberAlreadyExistsException(thing.SerialNumber);
        }
        await thingRepository.AddAsync(thing);
        await unitOfWork.CompleteAsync();
        return thing;
    }
}