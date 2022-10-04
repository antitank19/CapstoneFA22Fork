using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IServiceTypeRepository
    {
        public IQueryable<ServiceType> GetList();
        public IQueryable<ServiceType> GetDetail(int Id);
        public Task<ServiceType> Add(ServiceType entity);
        public Task<ServiceType> Update(ServiceType entity);
        public Task<bool> Delete(int id);
    }
}