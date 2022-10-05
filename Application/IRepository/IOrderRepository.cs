using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IOrderRepository
{
    public IQueryable<Order> GetOrderList();
    public IQueryable<Order> GetOrder(int orderId);
    public Task<Order> AddOrder(Order order);
    public Task<Order?> UpdateOrder(Order order);
    public Task<bool> DeleteOrder(int orderId);
}