using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace si730ebu202212721.API.Shared.Interfaces.ASP.Configuration.Extensions;

/**
 *  ModelStateExtensions
 * <summary>
 *    - Extension methods for ModelStateDictionary
 *    - GetErrorMessages: Get all error messages from ModelStateDictionary
 * </summary>
 * <remarks>
 *     - Author: U202212721 Mathias Jave Diaz
 *     - Version: 1.0.0
 * </remarks>
 */
public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary
            .SelectMany(m => m.Value!.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}