using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class PaymentTypeRepository : IPaymentTypeRepository
{
    private readonly ApplicationContext _context;

    public PaymentTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all payment types
    /// </summary>
    /// <returns></returns>
    public IQueryable<PaymentType> GetPaymentTypeList()
    {
        return _context.PaymentType.AsQueryable();
    }

    /// <summary>
    ///     Get payment type by id
    /// </summary>
    /// <param name="paymentTypeId"></param>
    /// <returns></returns>
    public IQueryable<PaymentType> GetPaymentTypeDetail(int paymentTypeId)
    {
        return _context.PaymentType
            .Where(x => x.PaymentTypeId == paymentTypeId);
    }

    /// <summary>
    ///     AddFeedback new payment type
    /// </summary>
    /// <param name="paymentType"></param>
    /// <returns></returns>
    public async Task<PaymentType> AddPaymentType(PaymentType paymentType)
    {
        await _context.PaymentType.AddAsync(paymentType);
        await _context.SaveChangesAsync();
        return paymentType;
    }

    /// <summary>
    ///     UpdateFeedback payment type
    /// </summary>
    /// <param name="paymentType"></param>
    /// <returns></returns>
    public async Task<PaymentType?> UpdatePaymentType(PaymentType? paymentType)
    {
        var paymentTypeData = await _context.PaymentType
            .FirstOrDefaultAsync(x => x.PaymentTypeId == paymentType!.PaymentTypeId);
        if (paymentTypeData == null)
            return null;

        paymentTypeData.PaymentName = paymentType?.PaymentName ?? paymentTypeData.PaymentName;
        paymentTypeData.PaymentStatus = paymentType?.PaymentStatus ?? paymentTypeData.PaymentStatus;

        await _context.SaveChangesAsync();
        return paymentTypeData;
    }

    /// <summary>
    ///     DeleteFeedback payment type
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public async Task<bool> DeletePaymentType(int paymentId)
    {
        var paymentTypeFound = await _context.PaymentType
            .FindAsync(paymentId.ToString());
        if (paymentTypeFound == null)
            return false;
        _context.PaymentType.Remove(paymentTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }
}