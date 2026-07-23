using EM.Planilla.Application.Results;
using System.Text.Json;

namespace EM.Planilla.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)         
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "unhandled exception procesing request: {0}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = StatusCodes.Status400BadRequest;
            var result = Result.Failure(exception.Message, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var payload = JsonSerializer.Serialize(result, options);

            await context.Response.WriteAsync(payload);
        }
    }
}
