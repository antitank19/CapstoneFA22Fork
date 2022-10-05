using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IPaymentTypeService
{
    public Task<IEnumerable<PaymentType?>> GetPaymentTypeList();
    public Task<PaymentType?> GetPaymentTypeById(int paymentTypeId);
    public Task<PaymentType?> AddPaymentType(PaymentType paymentType);
    public Task<PaymentType?> UpdatePaymentType(PaymentType paymentType);
    public Task<bool> DeletePaymentType(int paymentTypeId);
}