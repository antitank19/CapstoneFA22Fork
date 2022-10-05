using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class PaymentTypeService : IPaymentTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PaymentTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<PaymentType?>> GetPaymentTypeList()
    {
        return await _repositoryWrapper.PaymentTypes.GetPaymentTypeList()
            .ToListAsync();
    }

    public async Task<PaymentType?> GetPaymentTypeById(int paymentTypeId)
    {
        return await _repositoryWrapper.PaymentTypes.GetPaymentTypeDetail(paymentTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<PaymentType?> AddPaymentType(PaymentType paymentType)
    {
        return await _repositoryWrapper.PaymentTypes.AddPaymentType(paymentType);
    }

    public async Task<PaymentType?> UpdatePaymentType(PaymentType paymentType)
    {
        return await _repositoryWrapper.PaymentTypes.UpdatePaymentType(paymentType);
    }

    public async Task<bool> DeletePaymentType(int paymentTypeId)
    {
        return await _repositoryWrapper.PaymentTypes.DeletePaymentType(paymentTypeId);
    }
}