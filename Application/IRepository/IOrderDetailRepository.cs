using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IOrderDetailRepository
    {
        public IQueryable<OrderDetail> GetList();
        public IQueryable<OrderDetail> GetDetail(int Id);
        public Task<OrderDetail> Add(OrderDetail entity);
        public Task<OrderDetail> Update(OrderDetail entity);
        public Task<bool> Delete(int id);
    }
}