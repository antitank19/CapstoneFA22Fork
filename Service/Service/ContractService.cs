using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class ContractService : IContractService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}