using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class OrderDetailService : IOrderDetailService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public OrderDetailService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<OrderDetail?>> GetOrderDetailList()
    {
        return await _repositoryWrapper.OrderDetails.GetOrderDetailList()
            .ToListAsync();
    }

    public async Task<OrderDetail?> GetOrderDetailById(int orderDetailId)
    {
        return await _repositoryWrapper.OrderDetails.GetOrderDetail(orderDetailId)
            .FirstOrDefaultAsync();
    }

    public async Task<OrderDetail?> AddOrderDetail(OrderDetail orderDetail)
    {
        return await _repositoryWrapper.OrderDetails.AddOrderDetail(orderDetail);
    }

    public async Task<OrderDetail?> UpdateOrderDetail(OrderDetail orderDetail)
    {
        return await _repositoryWrapper.OrderDetails.UpdateOrderDetail(orderDetail);
    }

    public async Task<bool> DeleteOrderDetail(int orderDetailId)
    {
        return await _repositoryWrapper.OrderDetails.DeleteOrderDetail(orderDetailId);
    }
}