using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractHistoryService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}