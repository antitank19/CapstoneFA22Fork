using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class PaymentService : IPaymentService
{
    private readonly IRepositoryWrapper reposities;

    public PaymentService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}