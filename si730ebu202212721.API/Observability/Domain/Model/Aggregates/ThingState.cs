using si730ebu202212721.API.Inventory.Domain.Model.Aggregates;
using si730ebu202212721.API.Observability.Domain.Model.Commands;
using si730ebu202212721.API.Observability.Domain.Model.ValueObjects;

namespace si730ebu202212721.API.Observability.Domain.Model.Aggregates;

/// ThingState aggregate root
/// <summary>
///   - ThingState is the aggregate root for the Observability bounded context.
/// </summary>
/// <remarks>
///  - Author: U202212721 Mathias Jave Diaz
///   -Version: 1.0.0
/// </remarks>
public partial class ThingState
{
    public int Id { get; }
    public ThingSerialNumber ThingSerialNumberValueObject { get; private set; }
    public int CurrentOperationMode { get; set; }
    public decimal CurrentTemperature { get; set; }
    public decimal CurrentHumidity { get; set; }
    public DateTime CollectedAt { get; set; }
    
    public Thing Thing { get; private set; }
    
    public int ThingId { get; set; }
    
}

public partial class ThingState
{
    public string ThingSerialNumber => ThingSerialNumberValueObject.Value.ToString();
}

public partial class ThingState
{
    public ThingState()
    {
        CurrentHumidity = 0;
        CurrentTemperature = 0;
        CurrentOperationMode = 0;
        CollectedAt = DateTime.UtcNow;
        ThingSerialNumberValueObject = new ThingSerialNumber(Guid.Empty);
    }

    public ThingState(CreateThingStateCommand command)
    {
        CurrentHumidity = command.CurrentHumidity;
        CurrentTemperature = command.CurrentTemperature;
        CurrentOperationMode = command.CurrentOperationMode;
        CollectedAt = command.CollectedAt;
        ThingSerialNumberValueObject = new ThingSerialNumber(command.ThingSerialNumber);
        CreatedDate = DateTime.Now;
        UpdatedDate = null;


    }
    
    
}

