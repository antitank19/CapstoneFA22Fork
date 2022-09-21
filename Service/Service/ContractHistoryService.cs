using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly IRepositoryWrapper reposities;

    public ContractHistoryService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}