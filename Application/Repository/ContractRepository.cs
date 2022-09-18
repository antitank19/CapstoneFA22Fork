using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class ContractRepository : IContractRepository
{
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