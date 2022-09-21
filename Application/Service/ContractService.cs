using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class ContractService : IContractService
{
    private readonly IReposityWrapper reposities;

    public ContractService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}