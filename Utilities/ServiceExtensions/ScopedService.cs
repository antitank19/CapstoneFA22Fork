using Application.IRepository;
using Application.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IO;
using Service.IService;
using Service.Service;

namespace Utilities.ServiceExtensions;

public static class ScopedService
{
    public static IServiceCollection AddScopedService(this IServiceCollection services)
    {
        services.AddSingleton<RecyclableMemoryStreamManager>();
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        return services;
    }
}