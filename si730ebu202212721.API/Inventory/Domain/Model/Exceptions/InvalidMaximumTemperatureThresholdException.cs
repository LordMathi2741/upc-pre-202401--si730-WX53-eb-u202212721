namespace si730ebu202212721.API.Inventory.Domain.Model.Exceptions;

public class InvalidMaximumTemperatureThresholdException : Exception
{
    public InvalidMaximumTemperatureThresholdException(decimal maximumTemperatureThreshold) : base($"The maximum temperature threshold value {maximumTemperatureThreshold} is invalid. It must be between -40.00 and 80.00.")
    {
    }
}