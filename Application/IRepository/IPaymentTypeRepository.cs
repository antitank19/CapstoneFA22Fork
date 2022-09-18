using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IPaymentTypeRepository
{
    public IQueryable<PaymentType> GetPaymentTypeList();
    public IQueryable<PaymentType> GetPaymentTypeDetail(int paymentTypeId);
    public Task<PaymentType> AddPayment(PaymentType paymentType);
    public Task<PaymentType> UpdatePayment(PaymentType paymentType);
    public Task<bool> DeletePayment(int userId);
}