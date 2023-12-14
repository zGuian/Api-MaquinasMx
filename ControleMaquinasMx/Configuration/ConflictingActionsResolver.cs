using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ControleMaquinasMx.Configuration
{
    public class ConflictingActionsResolver : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor.RouteValues.ContainsKey("action"))
            {
                var actionName = context.ApiDescription.ActionDescriptor.RouteValues["action"];
                var controllerName = context.ApiDescription.ActionDescriptor.RouteValues["controller"];

                operation.OperationId = $"{controllerName}_{actionName}";
            }
        }
    }
}
