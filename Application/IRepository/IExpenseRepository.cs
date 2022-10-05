using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IExpenseRepository
{
    public IQueryable<Expense> GetExpenseList();
    public IQueryable<Expense> GetExpenseDetail(int expenseId);
    public Task<Expense> AddExpense(Expense expense);
    public Task<Expense?> UpdateExpense(Expense expense);
    public Task<bool> DeleteExpense(int expenseId);
}