using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class ContractService : IContractService
{
    private readonly IRepositoryWrapper reposities;

    public ContractService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}