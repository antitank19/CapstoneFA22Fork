using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ServiceEntityService : IServiceEntityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceEntityService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<ServiceEntity> GetServiceEntityList()
    {
        return _repositoryWrapper.ServiceEntities.GetServiceList();
    }

    public async Task<ServiceEntity?> GetServiceEntityById(int serviceEntityId)
    {
        return await _repositoryWrapper.ServiceEntities.GetServiceDetail(serviceEntityId)
            .FirstOrDefaultAsync();
    }

    public async Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.AddService(serviceEntity);
    }

    public async Task<ServiceEntity?> UpdateServiceEntity(ServiceEntity serviceEntity)
    {
        return await _repositoryWrapper.ServiceEntities.UpdateService(serviceEntity);
    }

    public async Task<bool> DeleteServiceEntity(int serviceEntityId)
    {
        return await _repositoryWrapper.ServiceEntities.DeleteService(serviceEntityId);
    }
}