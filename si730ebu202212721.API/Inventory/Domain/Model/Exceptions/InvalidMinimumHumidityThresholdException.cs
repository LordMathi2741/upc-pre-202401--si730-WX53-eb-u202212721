namespace si730ebu202212721.API.Inventory.Domain.Model.Exceptions;

public class InvalidMinimumHumidityThresholdException : Exception
{
    public InvalidMinimumHumidityThresholdException(decimal minimumHumidityThreshold) : base($"The minimum humidity threshold value {minimumHumidityThreshold} is invalid. It must be between 0.00 and 100.00.")
    {
    }
}