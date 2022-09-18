using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IContractRepository
{
    public IQueryable<Contract> GetContractList();
    public IQueryable<Contract> GetContractDetail(int contractId);
    public Task<ContractHistory> AddContract(Contract contract);
    public Task<ContractHistory> UpdateContract(Contract contract);
    public Task<bool> DeleteContract(Contract contract);
}