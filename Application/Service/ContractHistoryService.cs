using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly IRepositoryWrapper reposities;

    public ContractHistoryService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}