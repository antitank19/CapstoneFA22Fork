using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ContractHistoryService : IContractHistoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractHistoryService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<ContractHistory> GetContractHistoryList()
    {
        return _repositoryWrapper.ContractHistories.GetContractHistoryList();
    }

    public async Task<ContractHistory?> GetContractHistoryById(int contractHistoryId)
    {
        return await _repositoryWrapper.ContractHistories.GetContractHistoryDetail(contractHistoryId)
            .FirstOrDefaultAsync();
    }

    public async Task<ContractHistory?> AddContractHistory(ContractHistory contractHistory)
    {
        return await _repositoryWrapper.ContractHistories.AddContractHistory(contractHistory);
    }

    public async Task<ContractHistory?> UpdateContractHistory(ContractHistory contractHistory)
    {
        return await _repositoryWrapper.ContractHistories.UpdateContractHistory(contractHistory);
    }

    public async Task<bool> DeleteContractHistory(int contractHistoryId)
    {
        return await _repositoryWrapper.ContractHistories.DeleteContractHistory(contractHistoryId);
    }
}