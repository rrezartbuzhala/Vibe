using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rrezart.Vibe.Application.Exceptions;
using System.Net;

namespace Rrezart.Vibe.Host.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is PasswordIncorrectException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { Message = context.Exception.Message });
                return;
            }

            if(context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new JsonResult(new { Message = ((ValidationException)context.Exception).Errors });
                return;
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(new { Message = context.Exception.Message });
            return;
        }
    }
}
