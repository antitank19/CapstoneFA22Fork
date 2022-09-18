using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IPaymentRepository
{
    public IQueryable<Payment> GetPaymentList();
    public IQueryable<Payment> GetPaymentDetail(int paymentId);
    public Task<Payment> AddPayment(Payment payment);
    public Task<Payment> UpdatePayment(Payment payment);
    public Task<bool> DeletePayment(int userId);
}