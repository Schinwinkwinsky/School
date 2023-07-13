using School.Application.Results;
using System.Net;
using IResult = School.Application.Results.IResult;

namespace School.WebAPI.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
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

        await context.Response.WriteAsJsonAsync<IResult>(Result.Fail(exception.Message));
    }
}
