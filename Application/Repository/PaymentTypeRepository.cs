using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class PaymentTypeRepository : IPaymentTypeRepository
{
    public IQueryable<PaymentType> GetPaymentTypeList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<PaymentType> GetPaymentTypeDetail(int paymentTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentType> AddPayment(PaymentType paymentType)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentType> UpdatePayment(PaymentType paymentType)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePayment(int userId)
    {
        throw new NotImplementedException();
    }
}