using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class PaymentTypeService : IPaymentTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PaymentTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}