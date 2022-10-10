using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ServiceTypeService : IServiceTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ServiceTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<ServiceType> GetServiceTypeList()
    {
        return _repositoryWrapper.ServiceTypes.GetServiceTypeList();
    }

    public async Task<ServiceType?> GetServiceTypeById(int serviceTypeId)
    {
        return await _repositoryWrapper.ServiceTypes.GetServiceTypeDetail(serviceTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<ServiceType?> AddServiceType(ServiceType serviceType)
    {
        return await _repositoryWrapper.ServiceTypes.AddServiceType(serviceType);
    }

    public async Task<ServiceType?> UpdateServiceType(ServiceType serviceType)
    {
        return await _repositoryWrapper.ServiceTypes.UpdateServiceType(serviceType);
    }

    public async Task<bool> DeleteServiceType(int serviceTypeId)
    {
        return await _repositoryWrapper.ServiceTypes.DeleteServiceType(serviceTypeId);
    }
}