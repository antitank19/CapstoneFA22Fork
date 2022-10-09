using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class CorsService
{
    private const string MyCorsPolicy = "MyPolicy";

    public static IServiceCollection AddCustomCorsService(this IServiceCollection services)
    {
        services.AddCors(o => o.AddPolicy(MyCorsPolicy,
            corsPolicyBuilder =>
            {
                corsPolicyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

        return services;
    }

    public static void UseCustomCorsService(this WebApplication application)
    {
        application.UseCors(MyCorsPolicy);
    }
}