using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class PaymentTypeService : IPaymentTypeService
{
    private readonly IRepositoryWrapper reposities;

    public PaymentTypeService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}