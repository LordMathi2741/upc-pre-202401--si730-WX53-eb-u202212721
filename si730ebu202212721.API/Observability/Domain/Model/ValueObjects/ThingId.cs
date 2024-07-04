namespace si730ebu202212721.API.Observability.Domain.Model.ValueObjects;

/// ThingId Value object
/// <summary>
///   - Value object for the ThingId
///   - It is used to identify the Thing in the external bounded context
/// </summary>
/// <param name="Id"></param>
/// <remarks>
///    Author: U202212721 Mathias Jave Diaz
///    Version: 1.0.0
/// </remarks>
public record ThingId(int Id)
{
    public ThingId() : this(0)
    {
        
    }
}