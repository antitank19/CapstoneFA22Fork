using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IPaymentService
{
    public Task<IEnumerable<Payment?>> GetPaymentList();
    public Task<Payment?> GetPaymentById(int paymentId);
    public Task<Payment?> AddPayment(Payment payment);
    public Task<Payment?> UpdatePayment(Payment payment);
    public Task<bool> DeletePayment(int paymentId);
}