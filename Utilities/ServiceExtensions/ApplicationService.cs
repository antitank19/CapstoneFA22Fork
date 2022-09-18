using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services,
        string configuration)
    {
        services.AddDbContext<ApplicationContext>(option =>
            option.UseSqlServer(configuration));
        return services;
    }
}