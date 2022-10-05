using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ServiceEntityRepository : IServiceEntityRepository
{
    private readonly ApplicationContext _context;

    public ServiceEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all services
    /// </summary>
    /// <returns></returns>
    public IQueryable<ServiceEntity> GetServiceList()
    {
        return _context.Services.AsQueryable();
    }

    /// <summary>
    ///     Get serviceEntity by id
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    public IQueryable<ServiceEntity> GetServiceDetail(int serviceId)
    {
        return _context.Services
            .Where(x => x.ServiceId == serviceId);
    }

    /// <summary>
    ///     AddFeedback new serviceEntity
    /// </summary>
    /// <param name="serviceEntity"></param>
    /// <returns></returns>
    public async Task<ServiceEntity> AddService(ServiceEntity serviceEntity)
    {
        await _context.Services.AddAsync(serviceEntity);
        await _context.SaveChangesAsync();
        return serviceEntity;
    }

    /// <summary>
    ///     UpdateFeedback serviceEntity
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public async Task<ServiceEntity?> UpdateService(ServiceEntity? service)
    {
        var serviceData = await _context.Services
            .FirstOrDefaultAsync(x => x.ServiceId == service!.ServiceId);
        if (serviceData == null)
            return null;

        serviceData.ServiceTypeId = service?.ServiceTypeId ?? serviceData.ServiceTypeId;
        serviceData.Name = service?.Name ?? serviceData.Name;
        serviceData.Description = service?.Description ?? serviceData.Description;

        await _context.SaveChangesAsync();
        return serviceData;
    }

    /// <summary>
    ///     DeleteFeedback serviceEntity
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteService(int serviceId)
    {
        var serviceFound = await _context.Services
            .FindAsync(serviceId.ToString());
        if (serviceFound == null)
            return false;
        _context.Services.Remove(serviceFound);
        await _context.SaveChangesAsync();
        return true;
    }
}