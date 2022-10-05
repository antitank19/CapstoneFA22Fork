using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IContractHistoryService
{
    public Task<IEnumerable<ContractHistory?>> GetContractHistoryList();

    // TODO : Get contract history list by user Id
    public Task<ContractHistory?> GetContractHistoryById(int contractHistoryId);
    public Task<ContractHistory?> AddContractHistory(ContractHistory contractHistory);
    public Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory);
    public Task<bool> DeleteContractHistory(int contractHistoryId);
}