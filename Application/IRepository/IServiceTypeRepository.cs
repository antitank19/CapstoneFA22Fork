using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IServiceTypeRepository
{
    public IQueryable<ServiceType> GetServiceTypeList();
    public IQueryable<ServiceType> GetServiceTypeDetail(int serviceTypeId);
    public Task<ServiceType> AddServiceType(ServiceType serviceType);
    public Task<ServiceType?> UpdateServiceType(ServiceType serviceType);
    public Task<bool> DeleteServiceType(int serviceTypeId);
}