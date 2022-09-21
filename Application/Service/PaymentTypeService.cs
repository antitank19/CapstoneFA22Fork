using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class PaymentTypeService : IPaymentTypeService
{
    private readonly IReposityWrapper reposities;

    public PaymentTypeService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}