using EmployeeManagementAPI.Exceptions;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
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
            _logger.LogError(ex, ex.Message);

            await HandleException(context, ex);
        }
    }

    private static async Task HandleException(HttpContext context,Exception exception)
    {
        int statusCode;
        switch (exception)
        {
            case EmployeeNotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                break;

            case ValidationException:
                statusCode = StatusCodes.Status400BadRequest;
                break;

            default:
                statusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            StatusCode = statusCode,
            Message = exception.Message
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}