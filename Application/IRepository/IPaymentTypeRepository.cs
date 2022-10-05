using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IPaymentTypeRepository
{
    public IQueryable<PaymentType> GetPaymentTypeList();
    public IQueryable<PaymentType> GetPaymentTypeDetail(int paymentTypeId);
    public Task<PaymentType> AddPaymentType(PaymentType paymentType);
    public Task<PaymentType?> UpdatePaymentType(PaymentType paymentType);
    public Task<bool> DeletePaymentType(int paymentId);
}