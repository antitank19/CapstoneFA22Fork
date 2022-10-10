using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class OrderService : IOrderService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public OrderService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Order> GetOrderList()
    {
        return _repositoryWrapper.Orders.GetOrderList();
    }

    public async Task<Order?> GetOrderById(int orderId)
    {
        return await _repositoryWrapper.Orders.GetOrder(orderId)
            .FirstOrDefaultAsync();
    }

    public async Task<Order?> AddOrder(Order order)
    {
        return await _repositoryWrapper.Orders.AddOrder(order);
    }

    public async Task<Order?> UpdateOrder(Order order)
    {
        return await _repositoryWrapper.Orders.UpdateOrder(order);
    }

    public async Task<bool> DeleteOrder(int orderId)
    {
        return await _repositoryWrapper.Orders.DeleteOrder(orderId);
    }
}