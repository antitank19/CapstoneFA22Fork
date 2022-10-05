using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all orders
    /// </summary>
    /// <returns></returns>
    public IQueryable<Order> GetOrderList()
    {
        return _context.Orders.AsQueryable();
    }

    /// <summary>
    ///     Get order by id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    public IQueryable<Order> GetOrder(int orderId)
    {
        return _context.Orders
            .Where(x => x.OrderId == orderId);
    }

    /// <summary>
    ///     Add new order
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task<Order> AddOrder(Order order)
    {
        await _context.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    /// <summary>
    ///     Update order
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task<Order?> UpdateOrder(Order? order)
    {
        var orderData = await _context.Orders
            .FirstOrDefaultAsync(x => x.OrderId == order!.OrderId);
        if (orderData == null)
            return null;

        // TODO : Check if wanted to change other fields
        orderData.Name = order?.Name ?? orderData.Name;
        orderData.Status = order?.Status ?? orderData.Status;
        orderData.Details = order?.Details ?? orderData.Details;

        await _context.SaveChangesAsync();
        return orderData;
    }

    /// <summary>
    ///     Delete order
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteOrder(int orderId)
    {
        var orderFound = await _context.Orders
            .FindAsync(orderId.ToString());
        if (orderFound == null)
            return false;
        _context.Orders.Remove(orderFound);
        await _context.SaveChangesAsync();
        return true;
    }
}