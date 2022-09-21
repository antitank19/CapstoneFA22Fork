using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class TransactionService : ITransactionService
{
    private readonly IReposityWrapper reposities;

    public TransactionService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}