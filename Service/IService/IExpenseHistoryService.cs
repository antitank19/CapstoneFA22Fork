using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IExpenseHistoryService
{
    public IQueryable<ExpenseHistory> GetExpenseHistoryList();

    // TODO : Get expense history list by user Id
    public Task<ExpenseHistory?> GetExpenseHistoryById(int expenseHistoryId);
    public Task<ExpenseHistory?> AddExpenseHistory(ExpenseHistory expenseHistory);
    public Task<ExpenseHistory?> UpdateExpenseHistory(ExpenseHistory expenseHistory);
    public Task<bool> DeleteExpenseHistory(int expenseHistoryId);
}