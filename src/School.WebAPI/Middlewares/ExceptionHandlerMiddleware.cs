using School.Application.Results;
using System.Net;
using System.Text.Json;

namespace School.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case HttpRequestException ex:
                    _logger.LogInformation(exception.Message);
                    context.Response.StatusCode = (int)ex.StatusCode!;
                    break;

                default:
                    _logger.LogError(exception, "Application error.");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(Result.Fail(exception.Message));
            await context.Response.WriteAsync(result);
        }
    }
}
