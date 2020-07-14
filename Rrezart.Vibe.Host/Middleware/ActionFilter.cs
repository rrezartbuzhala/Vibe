using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rrezart.Vibe.Host.Middleware
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers["server"] = "Trralala";
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing ...");
        }
    }
}
