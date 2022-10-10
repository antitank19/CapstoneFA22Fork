using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IOrderDetailService
{
    public IQueryable<OrderDetail> GetOrderDetailList();
    public Task<OrderDetail?> GetOrderDetailById(int orderDetailId);
    public Task<OrderDetail?> AddOrderDetail(OrderDetail orderDetail);
    public Task<OrderDetail?> UpdateOrderDetail(OrderDetail orderDetail);
    public Task<bool> DeleteOrderDetail(int orderDetailId);
}