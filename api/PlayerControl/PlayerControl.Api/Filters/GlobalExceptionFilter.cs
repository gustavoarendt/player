using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayerControl.Application.Exceptions;
using PlayerControl.Domain.Validations;

namespace PlayerControl.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;

        public GlobalExceptionFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var details = new ProblemDetails();
            var exception = context.Exception;

            if (_environment.IsDevelopment())
            {
                details.Extensions.Add("StackTrace", exception.StackTrace);
            }

            if (exception is EntityValidationException)
            {
                var ex = exception as EntityValidationException;
                details.Title = "At least one validation error occurred";
                details.Status = StatusCodes.Status422UnprocessableEntity;
                details.Type = "UnprocessableEntity";
                details.Detail = ex!.Message;
            } else if (exception is NotFoundException) 
            {
                details.Title = "Not Found";
                details.Status = StatusCodes.Status404NotFound;
                details.Type = "NotFound";
                details.Detail = exception.Message;
            } else
            {
                details.Title = "Unexpected Error";
                details.Status = StatusCodes.Status400BadRequest;
                details.Type = "UnexpectedError";
                details.Detail = exception.Message;
            }

            context.HttpContext.Response.StatusCode = (int) details.Status;
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
