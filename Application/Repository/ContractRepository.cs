using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class ContractRepository : IContractRepository
{
    private readonly ApplicationContext context;

    public ContractRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Contract> GetContractList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Contract> GetContractDetail(int contractId)
    {
        throw new NotImplementedException();
    }

    public Task<ContractHistory> AddContract(Contract contract)
    {
        throw new NotImplementedException();
    }

    public Task<ContractHistory> UpdateContract(Contract contract)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteContract(Contract contract)
    {
        throw new NotImplementedException();
    }
}