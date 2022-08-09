using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class SimpleCacheAttribute : Attribute, IResourceFilter
    {
        private Dictionary<PathString, IActionResult> CachedResponses
            = new Dictionary<PathString, IActionResult>();

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            PathString path = context.HttpContext.Request.Path;

            if (CachedResponses.ContainsKey(path))
            {
                context.Result = CachedResponses[path];
                CachedResponses.Remove(path);
            }
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (context.Result != null)
            {
                CachedResponses.Add(context.HttpContext.Request.Path, context.Result);
            }
        }
    }
}