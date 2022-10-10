using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IServiceEntityService
{
    public IQueryable<ServiceEntity> GetServiceEntityList();
    public Task<ServiceEntity?> GetServiceEntityById(int serviceEntityId);
    public Task<ServiceEntity?> AddServiceEntity(ServiceEntity serviceEntity);
    public Task<ServiceEntity?> UpdateServiceEntity(ServiceEntity serviceEntity);
    public Task<bool> DeleteServiceEntity(int serviceEntityId);
}