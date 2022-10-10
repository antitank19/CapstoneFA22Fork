using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IContractService
{
    public IQueryable<Contract> GetContractList();

    // TODO : Get contract list by user Id
    public Task<Contract?> GetContractById(int contractId);
    public Task<Contract?> AddContract(Contract contract);
    public Task<Contract?> UpdateContract(Contract contract);
    public Task<bool> DeleteContract(int contractId);
}