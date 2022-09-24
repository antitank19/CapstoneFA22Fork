using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PaymentService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}