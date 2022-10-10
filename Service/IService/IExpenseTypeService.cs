using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IExpenseTypeService
{
    public IQueryable<ExpenseType> GetExpenseTypeList();

    // TODO : Get expense list by user Id
    public Task<ExpenseType?> GetExpenseTypeById(int expenseTypeId);
    public Task<ExpenseType?> AddExpenseType(ExpenseType expenseType);
    public Task<ExpenseType?> UpdateExpenseType(ExpenseType expenseType);
    public Task<bool> DeleteExpenseType(int expenseTypeId);
}