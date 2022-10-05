using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IOrderDetailRepository
{
    public IQueryable<OrderDetail> GetOrderDetailList();
    public IQueryable<OrderDetail> GetOrderDetail(int orderDetailId);
    public Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail);
    public Task<OrderDetail?> UpdateOrderDetail(OrderDetail orderDetail);
    public Task<bool> DeleteOrderDetail(int orderDetail);
}