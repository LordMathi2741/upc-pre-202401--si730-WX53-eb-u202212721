using Microsoft.AspNetCore.Mvc.ApplicationModels;
using si730ebu202212721.API.Shared.Interfaces.ASP.Configuration.Extensions;

namespace si730ebu202212721.API.Shared.Interfaces.ASP.Configuration;

/**
 * KebaCaseRouteNamingConvention
 * <summary>
 *      - This class is responsible for converting the controller name to kebab case.
 *     - This class is used to apply the kebab case naming convention to the controller and action routes.
 * </summary>
 * <remarks>
 *    - Author: U202212721 Mathias Jave Diaz
 *     - Version: 1.0.0
 * </remarks>
 */
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null 
            ? new AttributeRouteModel { Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase()) } 
            : null;
    }
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors) 
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors)) 
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        
    }
}