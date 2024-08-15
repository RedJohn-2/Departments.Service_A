using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Departments.Service_A.Filters
{
    public class AccessFilterAttribute : Attribute, IResourceFilter
    {
        private readonly string _authorizedIssuer;

        public AccessFilterAttribute(IConfiguration configuration)
        {
            _authorizedIssuer = configuration["AuthorizedIssuer"]!;
        }
        public void OnResourceExecuted(ResourceExecutedContext _) { }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string referrer = context.HttpContext.Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(referrer) || !referrer.StartsWith(_authorizedIssuer))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

        }
    }
}
