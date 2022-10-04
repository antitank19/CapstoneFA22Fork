using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IServiceRepository
    {
        public IQueryable<Service> GetList();
        public IQueryable<Service> GetDetail(int Id);
        public Task<Service> Add(Service entity);
        public Task<Service> Update(Service entity);
        public Task<bool> Delete(int id);
    }
}