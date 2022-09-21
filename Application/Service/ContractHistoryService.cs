using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly IReposityWrapper reposities;

    public ContractHistoryService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}