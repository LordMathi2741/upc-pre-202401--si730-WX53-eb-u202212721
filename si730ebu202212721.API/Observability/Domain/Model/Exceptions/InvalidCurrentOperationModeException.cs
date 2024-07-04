namespace si730ebu202212721.API.Observability.Domain.Model.Exceptions;

public class InvalidCurrentOperationModeException : Exception
{
    public InvalidCurrentOperationModeException(int currentOperationMode) : base($"The current operation mode {currentOperationMode} is invalid. It must be between 0 and 2.")
    {
    }
}