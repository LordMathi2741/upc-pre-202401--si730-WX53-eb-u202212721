using si730ebu202212721.API.Inventory.Domain.Model.Commands;
using si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;
using si730ebu202212721.API.Observability.Domain.Model.Aggregates;

namespace si730ebu202212721.API.Inventory.Domain.Model.Aggregates;


// Thing aggregate root
/// <summary>
///    This class represents the aggregate root for the Inventory bounded context.
/// </summary>
///<remarks>
///   Author: U202212721 Mathias Jave Diaz
///   Version: 1.0.0
/// </remarks>
/// 
public partial class Thing
{
    public int Id { get; }
    public SerialNumber SerialNumberValueObject { get; }
    public string Model { get; set; }
    public decimal  MaximumTemperatureThreshold { get; set; }
    public decimal  MinimumHumidityThreshold { get; set; }
    public EOperationMode OperationMode { get; set; }
    
    public ICollection<ThingState> ThingStates { get; private set; }
    
}


public partial class Thing
{
    public string SerialNumber => SerialNumberValueObject.Value.ToString();
}

public partial class Thing
{
    public Thing()
    {
        Model = string.Empty;
        MaximumTemperatureThreshold = 0;
        MinimumHumidityThreshold = 0;
    }

    public Thing(CreateThingCommand command)
    {
        Model = command.Model;
        MaximumTemperatureThreshold = command.MaximumTemperatureThreshold;
        MinimumHumidityThreshold = command.MinimumHumidityThreshold;
        CreatedDate = DateTime.UtcNow;
        OperationMode = EOperationMode.ScheduleDriven;
        UpdatedDate = null;
        SerialNumberValueObject = new SerialNumber();
    }
}
