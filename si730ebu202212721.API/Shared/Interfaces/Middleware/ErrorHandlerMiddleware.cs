using System.Data;
using System.Net;
using si730ebu202212721.API.Inventory.Domain.Model.Exceptions;
using si730ebu202212721.API.Observability.Domain.Model.Exceptions;

namespace si730ebu202212721.API.Shared.Interfaces.Middleware;

/**
 *  ErrorHandlerMiddleware
 * <summary>
 *    - Middleware to handle exceptions and return a response with the appropriate status code.
 *    - The middleware is added to the pipeline in the Startup.cs file.
 *     - The Invoke method is called when the middleware is executed.
 *    - Follow middleware pattern to handle exceptions.
 * </summary>
 * <remarks>
 *    - Author : U202212721 Mathias Jave Diaz
 *    - Version: 1.0
 * </remarks>
 */
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    
    public ErrorHandlerMiddleware(RequestDelegate requestDelegate)
    {
        _next = requestDelegate;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = exception.Message;

        if (exception is InvalidMaximumTemperatureThresholdException || exception is InvalidMinimumHumidityThresholdException
            || exception is CollectedAtCannotBeInTheFutureException || exception is InvalidCurrentOperationModeException)
        {
            code = HttpStatusCode.BadRequest;
        }

        if (exception is ConstraintException || exception is DuplicateNameException || exception is SerialNumberAlreadyExistsException
            || exception is ThingSerialNumberDoesntExistsException ||  exception is ThingStateWithThisThingSerialNumberAndCollectedAtAlreadyExistsException)
        {
            code = HttpStatusCode.Conflict;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(result);
    }
}