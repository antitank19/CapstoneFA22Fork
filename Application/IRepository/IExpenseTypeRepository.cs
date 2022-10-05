using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IExpenseTypeRepository
{
    public IQueryable<ExpenseType> GetExpenseTypeList();
    public IQueryable<ExpenseType> GetExpenseTypeDetail(int expenseTypeId);
    public Task<ExpenseType> AddExpenseType(ExpenseType expenseType);
    public Task<ExpenseType?> UpdateExpenseType(ExpenseType expenseType);
    public Task<bool> DeleteExpenseType(int expenseTypeId);
}