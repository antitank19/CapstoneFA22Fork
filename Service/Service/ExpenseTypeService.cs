using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ExpenseTypeService : IExpenseTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ExpenseTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<ExpenseType?>> GetExpenseTypeList()
    {
        return await _repositoryWrapper.ExpenseTypes.GetExpenseTypeList()
            .ToListAsync();
    }

    public async Task<ExpenseType?> GetExpenseTypeById(int expenseTypeId)
    {
        return await _repositoryWrapper.ExpenseTypes.GetExpenseTypeDetail(expenseTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<ExpenseType?> AddExpenseType(ExpenseType expenseType)
    {
        return await _repositoryWrapper.ExpenseTypes.AddExpenseType(expenseType);
    }

    public async Task<ExpenseType?> UpdateExpenseType(ExpenseType expenseType)
    {
        return await _repositoryWrapper.ExpenseTypes.UpdateExpenseType(expenseType);
    }

    public async Task<bool> DeleteExpenseType(int expenseTypeId)
    {
        return await _repositoryWrapper.ExpenseTypes.DeleteExpenseType(expenseTypeId);
    }
}