using System.Text.RegularExpressions;

namespace si730ebu202212721.API.Shared.Interfaces.ASP.Configuration.Extensions;

/**
 *  StringExtensions
 *  <summary>
 *    - Contains extension methods for string manipulation.
 *    -  ToKebabCase: Converts a string to kebab case.
 *    - ToSnakeCase: Converts a string to snake case.
 * </summary>
 *  <remarks>
 *     - Author: U202212721 Mathias Jave Diaz
 *     - Version: 1.0.0
 * </remarks>
 */
public static partial class StringExtensions
{
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}