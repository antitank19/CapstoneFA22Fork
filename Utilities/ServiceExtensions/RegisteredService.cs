using Application.IRepository;
using Application.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Service.IService;
using Service.Service;
using Utilities.Extension;

namespace Utilities.ServiceExtensions;

public static class RegisteredService
{
    public static IServiceCollection AddRegisteredService(this IServiceCollection services,
        IConfiguration configuration)
    {
        // RecyclableMemoryStreamManager serviceEntity register 
        services.AddScoped<RecyclableMemoryStreamManager>();

        // wrapper services register
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        // logging check
        var isEnabled = configuration.GetSection("LogSettings:IsLoggerEnabled").Value;

        Console.WriteLine(isEnabled);
        if (isEnabled != "True")
            return services;
        Console.WriteLine("Logging enabled");
        //services.AddSingleton<LoggingExtension>();

        return services;
    }
}