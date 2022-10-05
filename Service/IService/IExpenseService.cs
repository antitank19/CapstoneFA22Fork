using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IExpenseService
{
    public Task<IEnumerable<Expense?>> GetExpenseList();

    // TODO : Get expense list by user Id
    public Task<Expense?> GetExpenseById(int expenseId);
    public Task<Expense?> AddExpense(Expense expense);
    public Task<Expense?> UpdateExpense(Expense expense);
    public Task<bool> DeleteExpense(int expenseId);
}