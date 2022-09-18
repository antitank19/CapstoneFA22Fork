using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class PaymentRepository : IPaymentRepository
{
    public IQueryable<Payment> GetPaymentList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Payment> GetPaymentDetail(int paymentId)
    {
        throw new NotImplementedException();
    }

    public Task<Payment> AddPayment(Payment payment)
    {
        throw new NotImplementedException();
    }

    public Task<Payment> UpdatePayment(Payment payment)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePayment(int userId)
    {
        throw new NotImplementedException();
    }

}