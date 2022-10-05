using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IServiceTypeService
{
    public Task<IEnumerable<ServiceType?>> GetServiceTypeList();
    public Task<ServiceType?> GetServiceTypeById(int serviceTypeId);
    public Task<ServiceType?> AddServiceType(ServiceType serviceType);
    public Task<ServiceType?> UpdateServiceType(ServiceType serviceType);
    public Task<bool> DeleteServiceType(int serviceTypeId);
}