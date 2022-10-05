using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationContext _context;

    public PaymentRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all payments
    /// </summary>
    /// <returns></returns>
    public IQueryable<Payment> GetPaymentList()
    {
        return _context.Payments.AsQueryable();
    }

    /// <summary>
    ///     Get payment by id
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public IQueryable<Payment> GetPaymentDetail(int paymentId)
    {
        return _context.Payments
            .Where(x => x.PaymentId == paymentId);
    }

    /// <summary>
    ///     AddFeedback new payment
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    public async Task<Payment> AddPayment(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
        return payment;
    }


    /// <summary>
    ///     UpdateFeedback payment
    /// </summary>
    /// <param name="payment"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Payment?> UpdatePayment(Payment? payment)
    {
        var paymentData = await _context.Payments
            .FirstOrDefaultAsync(x => x.PaymentId == payment!.PaymentId);
        if (paymentData == null)
            return null;
        paymentData.Amount = payment?.Amount ?? paymentData.Amount;
        paymentData.Detail = payment?.Detail ?? paymentData.Detail;
        paymentData.Status = payment?.Status ?? paymentData.Status;
        paymentData.PaymentTime = payment?.PaymentTime ?? paymentData.PaymentTime;
        paymentData.PaymentPeriod = payment?.PaymentPeriod ?? paymentData.PaymentPeriod;
        paymentData.PaymentTypeId = payment?.PaymentTypeId ?? paymentData.PaymentTypeId;

        await _context.SaveChangesAsync();

        return paymentData;
    }

    /// <summary>
    ///     DeleteFeedback payment
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public async Task<bool> DeletePayment(int paymentId)
    {
        var paymentFound = await _context.Payments
            .FindAsync(paymentId.ToString());
        if (paymentFound == null)
            return false;
        _context.Payments.Remove(paymentFound);
        await _context.SaveChangesAsync();
        return true;
    }
}