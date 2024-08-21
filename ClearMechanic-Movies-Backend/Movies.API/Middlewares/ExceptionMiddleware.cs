using Movies.Application.Models.Responses.Handlers;
using System.Net;
using System.Text.Json;

namespace Movies.API.Middlewares;

public class ExceptionMiddleware(
    RequestDelegate _next
    )
{
    public async Task InvokeAsync(HttpContext context)
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
    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var resultJson = JsonSerializer.Serialize(
            Result<Exception>.Failure(ex.InnerException is not null ? [ex.InnerException.Message] : [ex.Message])
        );

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(resultJson);
    }
}
