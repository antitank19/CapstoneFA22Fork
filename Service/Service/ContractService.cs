using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ContractService : IContractService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ContractService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Contract?>> GetContractList()
    {
        return await _repositoryWrapper.Contracts.GetContractList()
            .ToListAsync();
    }

    public async Task<Contract?> GetContractById(int contractId)
    {
        return await _repositoryWrapper.Contracts.GetContractDetail(contractId)
            .FirstOrDefaultAsync();
    }

    public async Task<Contract?> AddContract(Contract contract)
    {
        return await _repositoryWrapper.Contracts.AddContract(contract);
    }

    public async Task<Contract?> UpdateContract(Contract contract)
    {
        return await _repositoryWrapper.Contracts.UpdateContract(contract);
    }

    public async Task<bool> DeleteContract(int contractId)
    {
        return await _repositoryWrapper.Contracts.DeleteContract(contractId);
    }
}