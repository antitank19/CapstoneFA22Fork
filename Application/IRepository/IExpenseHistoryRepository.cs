using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IExpenseHistoryRepository
{
    public IQueryable<ExpenseHistory> GetExpenseList();
    public IQueryable<ExpenseHistory> GetExpenseDetail(int expenseId);
    public Task<ExpenseHistory> AddExpenseHistory(ExpenseHistory expenseHistoryId);
    public Task<ExpenseHistory?> UpdateExpenseHistory(ExpenseHistory expenseHistoryId);
    public Task<bool> DeleteExpenseHistory(int expenseHistoryId);
}