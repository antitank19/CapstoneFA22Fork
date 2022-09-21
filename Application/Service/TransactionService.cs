using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class TransactionService : ITransactionService
{
    private readonly IRepositoryWrapper reposities;

    public TransactionService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}