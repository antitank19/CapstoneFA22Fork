using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IOrderService
{
    public Task<IEnumerable<Order?>> GetOrderList();
    public Task<Order?> GetOrderById(int orderId);
    public Task<Order?> AddOrder(Order order);
    public Task<Order?> UpdateOrder(Order order);
    public Task<bool> DeleteOrder(int orderId);
}