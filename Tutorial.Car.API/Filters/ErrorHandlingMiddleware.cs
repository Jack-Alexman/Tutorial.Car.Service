using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Tutorial.Car.Common.Exceptions;

namespace Tutorial.Car.API.Filters
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = JsonConvert.SerializeObject(GetExceptionModel(exception));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetStatusCode(exception);
            return context.Response.WriteAsync(result);
        }

        private HttpStatusCode GetStatusCode(Exception exception)
        {
            if (exception is BusinessLogicException)
            {
                return HttpStatusCode.BadRequest;
            }

            if (exception is NotFoundException)
            {
                return HttpStatusCode.NotFound;
            }

            if (exception is UnauthorizedException)
            {
                return HttpStatusCode.Unauthorized;
            }

            return HttpStatusCode.InternalServerError;
        }

        private ExceptionModel GetExceptionModel(Exception exception)
        {
            return new ExceptionModel
            {
                Message = exception.Message,
                Source = exception.Source,
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException != null ? GetExceptionModel(exception.InnerException) : null
            };
        }
    }
}
