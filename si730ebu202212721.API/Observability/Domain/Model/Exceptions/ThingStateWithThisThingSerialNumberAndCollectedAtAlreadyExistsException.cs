namespace si730ebu202212721.API.Observability.Domain.Model.Exceptions;

public class ThingStateWithThisThingSerialNumberAndCollectedAtAlreadyExistsException : Exception
{
    public ThingStateWithThisThingSerialNumberAndCollectedAtAlreadyExistsException(string thingSerialNumber, DateTime collectedAt) : base($"Thing state with this thing serial number {thingSerialNumber} and collected at {collectedAt} already exists.")
    {
    }
}