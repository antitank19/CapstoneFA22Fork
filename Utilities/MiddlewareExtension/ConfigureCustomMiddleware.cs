using Microsoft.AspNetCore.Builder;
using Utilities.Middleware;

namespace Utilities.MiddlewareExtension;

public static class ConfigureCustomMiddleware
{
    public static IApplicationBuilder ConfigMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpLoggingMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}