using System.Net;
using System.Text.Json;
using Plataforma.Gym.WebApi.Shared.Exceptions;
using Plataforma.Gym.WebApi.Shared.Models;

namespace Plataforma.Gym.WebApi.Shared.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var eventId = new EventId(0, "Error");
                logger.LogError(eventId, "Global Exceptions Handler", error);

                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {

                    // custom application error
                    ModelValidationException _ => (int)HttpStatusCode.BadRequest,

                    ArgumentException _ => (int)HttpStatusCode.BadRequest,

                    // not found error
                    KeyNotFoundException _ => (int)HttpStatusCode.NotFound,

                    // unhandled error
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                var result = JsonSerializer.Serialize(
                    new Error(response.StatusCode, error?.Message)
                );
                await response.WriteAsync(result);
            }
        }
    }
}