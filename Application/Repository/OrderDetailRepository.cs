using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class OrderDetailRepository : IOrderDetailRepository
{
    private readonly ApplicationContext _context;

    public OrderDetailRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all order details
    /// </summary>
    /// <returns></returns>
    public IQueryable<OrderDetail> GetOrderDetailList()
    {
        return _context.OrderDetails.AsQueryable();
    }

    /// <summary>
    ///     Get OrderDetail by Id
    /// </summary>
    /// <param name="orderDetailId"></param>
    /// <returns></returns>
    public IQueryable<OrderDetail> GetOrderDetail(int orderDetailId)
    {
        return _context.OrderDetails
            .Where(x => x.OrderDetailId == orderDetailId);
    }

    /// <summary>
    ///     Add new OrderDetail
    /// </summary>
    /// <param name="orderDetail"></param>
    /// <returns></returns>
    public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
    {
        await _context.OrderDetails.AddAsync(orderDetail);
        await _context.SaveChangesAsync();
        return orderDetail;
    }

    /// <summary>
    ///     Update OrderDetail
    /// </summary>
    /// <param name="orderDetail"></param>
    /// <returns></returns>
    public async Task<OrderDetail?> UpdateOrderDetail(OrderDetail? orderDetail)
    {
        var orderDetailData = await _context.OrderDetails
            .FirstOrDefaultAsync(x => x.OrderDetailId == orderDetail!.OrderDetailId);
        if (orderDetailData == null)
            return null;

        // TODO : Check if the orderDetail is null and what fields need to be updated
        orderDetailData.Amount = orderDetail?.Amount ?? orderDetailData.Amount;

        await _context.SaveChangesAsync();
        return orderDetailData;
    }

    /// <summary>
    ///     Delete OrderDetail
    /// </summary>
    /// <param name="orderDetailId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteOrderDetail(int orderDetailId)
    {
        var orderDetailFound = await _context.OrderDetails
            .FindAsync(orderDetailId.ToString());
        if (orderDetailFound == null)
            return false;
        _context.OrderDetails.Remove(orderDetailFound);
        await _context.SaveChangesAsync();
        return true;
    }
}