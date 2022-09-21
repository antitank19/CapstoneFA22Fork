using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class ContractHistoryRepository : IContractHistoryRepository
{
    private readonly ApplicationContext context;

    public ContractHistoryRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<ContractHistory> GetContractHistoryList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<ContractHistory> GetContractHistoryDetail(int contractHistoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ContractHistory> AddContractHistory(ContractHistory contractHistory)
    {
        throw new NotImplementedException();
    }

    public Task<ContractHistory> UpdateContractHistory(ContractHistory contractHistory)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteContractHistory(ContractHistory contractHistory)
    {
        throw new NotImplementedException();
    }
}