using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ExpenseTypeRepository : IExpenseTypeRepository
{
    private readonly ApplicationContext _context;

    public ExpenseTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all expense types
    /// </summary>
    /// <returns></returns>
    public IQueryable<ExpenseType> GetExpenseTypeList()
    {
        return _context.ExpenseTypes.AsQueryable();
    }

    /// <summary>
    ///     Get ExpenseType by Id
    /// </summary>
    /// <param name="expenseTypeId"></param>
    /// <returns></returns>
    public IQueryable<ExpenseType> GetExpenseTypeDetail(int expenseTypeId)
    {
        return _context.ExpenseTypes
            .Where(x => x.ExpenseTypeId == expenseTypeId);
    }

    /// <summary>
    ///     AddFeedback new ExpenseType
    /// </summary>
    /// <param name="expenseType"></param>
    /// <returns></returns>
    public async Task<ExpenseType> AddExpenseType(ExpenseType expenseType)
    {
        await _context.ExpenseTypes.AddAsync(expenseType);
        await _context.SaveChangesAsync();
        return expenseType;
    }

    /// <summary>
    ///     UpdateFeedback ExpenseType in database
    /// </summary>
    /// <param name="expenseType"></param>
    /// <returns></returns>
    public async Task<ExpenseType?> UpdateExpenseType(ExpenseType? expenseType)
    {
        var expenseTypeData = await _context.ExpenseTypes
            .FirstOrDefaultAsync(x => x.ExpenseTypeId == expenseType!.ExpenseTypeId);
        if (expenseTypeData == null)
            return null;

        expenseTypeData.Name = expenseType?.Name ?? expenseTypeData.Name;
        expenseTypeData.ExpenseTypeId = expenseType?.ExpenseTypeId ?? expenseTypeData.ExpenseTypeId;
        expenseTypeData.Price = expenseType?.Price ?? expenseTypeData.Price;
        expenseTypeData.Status = expenseType?.Status ?? expenseTypeData.Status;

        await _context.SaveChangesAsync();
        return expenseTypeData;
    }

    /// <summary>
    ///     DeleteFeedback ExpenseType
    /// </summary>
    /// <param name="expenseTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteExpenseType(int expenseTypeId)
    {
        var expenseTypeFound = await _context.ExpenseTypes
            .FindAsync(expenseTypeId.ToString());
        if (expenseTypeFound == null)
            return false;
        _context.ExpenseTypes.Remove(expenseTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }
}