using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IOrderRepository
    {

        public IQueryable<Order> GetList();
        public IQueryable<Order> GetDetail(int Id);
        public Task<Order> Add(Order entity);
        public Task<Order> Update(Order entity);
        public Task<bool> Delete(int id);
    }
}