namespace si730ebu202212721.API.Inventory.Domain.Model.Exceptions;

public class SerialNumberAlreadyExistsException : Exception
{
    public SerialNumberAlreadyExistsException(string serialNumber) : base($"Serial number {serialNumber} already exists.")
    {
    }
}