using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class AuthorizationService
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            o.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
            o.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
            o.AddPolicy("Student", policy => policy.RequireClaim("Student"));
        });
        return services;
    }
}