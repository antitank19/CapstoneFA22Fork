using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class PaymentTypeRepository : IPaymentTypeRepository
{
    private readonly ApplicationContext context;

    public PaymentTypeRepository(ApplicationContext context)
    {
        this.context = context;
    }

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