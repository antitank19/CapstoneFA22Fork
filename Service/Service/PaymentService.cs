using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PaymentService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Payment> GetPaymentList()
    {
        return _repositoryWrapper.Payments.GetPaymentList()
            .AsQueryable();
    }

    public async Task<Payment?> GetPaymentById(int paymentId)
    {
        return await _repositoryWrapper.Payments.GetPaymentDetail(paymentId)
            .FirstOrDefaultAsync();
    }

    public async Task<Payment?> AddPayment(Payment payment)
    {
        return await _repositoryWrapper.Payments.AddPayment(payment);
    }

    public async Task<Payment?> UpdatePayment(Payment payment)
    {
        return await _repositoryWrapper.Payments.UpdatePayment(payment);
    }

    public async Task<bool> DeletePayment(int paymentId)
    {
        return await _repositoryWrapper.Payments.DeletePayment(paymentId);
    }
}