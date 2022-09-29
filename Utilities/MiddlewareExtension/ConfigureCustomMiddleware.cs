using Microsoft.AspNetCore.Builder;
using Utilities.BindEntities;
using Utilities.Middleware;

namespace Utilities.MiddlewareExtension;


public static class ConfigureCustomMiddleware
{
    private static LogSettings configuration;
    public static IApplicationBuilder ConfigMiddleware(this IApplicationBuilder app)
    {
        if (configuration.IsLoggerEnabled)
        {
            app.UseMiddleware<LoggingMiddleware>();
        }
        return app;
    }
    
}