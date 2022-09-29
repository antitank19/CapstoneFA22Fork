using Application.IRepository;
using Application.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Service.IService;
using Service.Service;
using Utilities.BindEntities;
using Utilities.Extension;

namespace Utilities.ServiceExtensions;

public static class RegisteredService
{
    public static IServiceCollection AddRegisteredService(this IServiceCollection services, 
        IConfiguration configuration)
    {
        // RecyclableMemoryStreamManager service register 
        services.AddScoped<RecyclableMemoryStreamManager>();

        // wrapper services register
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        
        // logging to file service register 
        services.Configure<LogSettings>(configuration.GetSection("IsLoggerEnabled"));

        var isEnabled = configuration.GetSection("IsLoggerEnabled").Value;
        if (isEnabled == "true")
        {
            services.AddScoped<LoggingExtension>();
        }

        return services;
    }
}