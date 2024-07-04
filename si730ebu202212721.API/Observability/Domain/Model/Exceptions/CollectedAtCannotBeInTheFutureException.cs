namespace si730ebu202212721.API.Observability.Domain.Model.Exceptions;

public class CollectedAtCannotBeInTheFutureException : Exception
{
    public CollectedAtCannotBeInTheFutureException(DateTime collectedAt) : base($"CollectedAt cannot be in the future. CollectedAt: {collectedAt}")
    {
    }
}