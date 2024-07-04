namespace si730ebu202212721.API.Inventory.Domain.Model.ValueObjects;

/// SerialNumber value object
/// <summary>
///   - This class represents the serial number value object for the Inventory bounded context.
/// </summary>
/// <param name="Value"></param>
/// <remarks>
///    Author: U202212721 Mathias Jave Diaz
///    Version: 1.0.0
/// </remarks>
public record SerialNumber(Guid Value)
{
    public SerialNumber() : this(Guid.NewGuid())
    {
    }
}