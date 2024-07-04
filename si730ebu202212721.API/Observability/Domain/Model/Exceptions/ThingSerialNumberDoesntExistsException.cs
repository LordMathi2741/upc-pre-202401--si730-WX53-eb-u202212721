namespace si730ebu202212721.API.Observability.Domain.Model.Exceptions;

public class ThingSerialNumberDoesntExistsException : Exception
{
    public ThingSerialNumberDoesntExistsException(string serialNumber) : base($"The serial number {serialNumber} doesn't exists.")
    {
    }
}