namespace si730ebu202212721.API.Observability.Domain.Model.ValueObjects;

/// <summary>
///   ThingSerialNumber Value Object
/// </summary>
/// <param name="Value"></param>
/// <remarks>
///   - Author: U202212721 Mathias Jave Diaz
///   - Version: 1.0.0
/// </remarks>
public record ThingSerialNumber(Guid Value)
{
    public ThingSerialNumber(string value) : this(Guid.Parse(value))
    {
        
    }
}