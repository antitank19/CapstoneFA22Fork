using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ExpenseHistoryService : IExpenseHistoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ExpenseHistoryService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<ExpenseHistory> GetExpenseHistoryList()
    {
        return _repositoryWrapper.ExpenseHistories.GetExpenseList();
        ;
    }

    public async Task<ExpenseHistory?> GetExpenseHistoryById(int expenseHistoryId)
    {
        return await _repositoryWrapper.ExpenseHistories.GetExpenseDetail(expenseHistoryId)
            .FirstOrDefaultAsync();
    }

    public async Task<ExpenseHistory?> AddExpenseHistory(ExpenseHistory expenseHistory)
    {
        return await _repositoryWrapper.ExpenseHistories.AddExpenseHistory(expenseHistory);
    }

    public async Task<ExpenseHistory?> UpdateExpenseHistory(ExpenseHistory expenseHistory)
    {
        return await _repositoryWrapper.ExpenseHistories.UpdateExpenseHistory(expenseHistory);
    }

    public async Task<bool> DeleteExpenseHistory(int expenseHistoryId)
    {
        return await _repositoryWrapper.ExpenseHistories.DeleteExpenseHistory(expenseHistoryId);
    }
}