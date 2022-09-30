using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class CorsService
{
    public static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy("MyPolicy",
            corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

        return services;
    }
}