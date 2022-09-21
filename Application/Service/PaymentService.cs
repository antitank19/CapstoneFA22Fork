using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class PaymentService : IPaymentService
{
    private readonly IReposityWrapper reposities;

    public PaymentService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}