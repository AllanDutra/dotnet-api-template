using System.Net;
using Template.Core;
using Template.Core.Models.ViewModels;

namespace Template.Api.Middlewares;

public class GlobalExceptionMiddleware(IServiceProvider serviceProvider) : IMiddleware
{
    private const string DEFAULT_ERROR_MESSAGE =
        "Tivemos um problema interno no servidor, tente novamente mais tarde!";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        var errorMessage =
            Variables.General.Env != "dev"
                ? DEFAULT_ERROR_MESSAGE
                : (exception.InnerException?.Message ?? exception.Message ?? DEFAULT_ERROR_MESSAGE);

        serviceProvider
            .GetRequiredService<ILogger<GlobalExceptionMiddleware>>()
            .LogError(exception, "{Message}. {StackTrace}.", errorMessage, exception.StackTrace);

        if (httpContext != null)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(
                new DefaultResponseViewModel(
                    [
                        Variables.General.Env != "dev"
                            ? DEFAULT_ERROR_MESSAGE
                            : (
                                exception.InnerException?.Message
                                ?? exception.Message
                                ?? DEFAULT_ERROR_MESSAGE
                            ),
                    ]
                )
            );
        }
    }
}
