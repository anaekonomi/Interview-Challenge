using BeerAPI.Models;
using System.Net;

namespace BeerAPI.Extensions
{
    /// <summary>
    /// Exception middleware for handling internal server errors occurring in API
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the global exception handler when an error is thrown
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string message;

            switch (exception)
            {
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "An internal API error occurred!";
                    break;
            }

            await context.Response.WriteAsJsonAsync(new ExceptionResponse
            {
                Message = message,
                Errors = exception.Message
            });
        }
    }
}