using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IContractHistoryRepository
{
    public IQueryable<ContractHistory> GetContractHistoryList();
    public IQueryable<ContractHistory> GetContractHistoryDetail(int contractHistoryId);
    public Task<ContractHistory> AddContractHistory(ContractHistory contractHistory);
    public Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory);
    public Task<bool> DeleteContractHistory(int contractHistory);
}