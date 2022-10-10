using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ExpenseService : IExpenseService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ExpenseService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Expense> GetExpenseList()
    {
        return _repositoryWrapper.Expenses.GetExpenseList();
    }

    public async Task<Expense?> GetExpenseById(int expenseId)
    {
        return await _repositoryWrapper.Expenses.GetExpenseDetail(expenseId)
            .FirstOrDefaultAsync();
    }

    public async Task<Expense?> AddExpense(Expense expense)
    {
        return await _repositoryWrapper.Expenses.AddExpense(expense);
    }

    public async Task<Expense?> UpdateExpense(Expense expense)
    {
        return await _repositoryWrapper.Expenses.UpdateExpense(expense);
    }

    public async Task<bool> DeleteExpense(int expenseId)
    {
        return await _repositoryWrapper.Expenses.DeleteExpense(expenseId);
    }
}