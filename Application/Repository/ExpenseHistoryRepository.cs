using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ExpenseHistoryRepository : IExpenseHistoryRepository
{
    private readonly ApplicationContext _context;

    public ExpenseHistoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all expense history
    /// </summary>
    /// <returns></returns>
    public IQueryable<ExpenseHistory> GetExpenseList()
    {
        return _context.ExpenseHistories.AsQueryable();
    }

    /// <summary>
    ///     Get expense history by id
    /// </summary>
    /// <param name="expenseHistoryId"></param>
    /// <returns></returns>
    public IQueryable<ExpenseHistory> GetExpenseDetail(int expenseHistoryId)
    {
        return _context.ExpenseHistories
            .Where(x => x.ExpenseHistoryId == expenseHistoryId);
    }

    /// <summary>
    ///     AddFeedback new expense history to database
    /// </summary>
    /// <param name="expenseHistory"></param>
    /// <returns></returns>
    public async Task<ExpenseHistory> AddExpenseHistory(ExpenseHistory expenseHistory)
    {
        await _context.ExpenseHistories.AddAsync(expenseHistory);
        await _context.SaveChangesAsync();
        return expenseHistory;
    }

    /// <summary>
    ///     UpdateFeedback expense history by id
    /// </summary>
    /// <param name="expenseHistory"></param>
    /// <returns></returns>
    public async Task<ExpenseHistory?> UpdateExpenseHistory(ExpenseHistory? expenseHistory)
    {
        var expenseHistoryData = await _context.ExpenseHistories
            .FirstOrDefaultAsync(x => x.ExpenseHistoryId == expenseHistory!.ExpenseHistoryId);
        // var test = await _context.ExpenseHistories.FindAsync(expenseHistory!.ExpenseHistoryId.ToString());
        if (expenseHistoryData == null)
            return null;

        expenseHistoryData.Name = expenseHistory?.Name ?? expenseHistoryData.Name;
        expenseHistoryData.Date = expenseHistory?.Date ?? expenseHistoryData.Date;

        await _context.SaveChangesAsync();
        return expenseHistoryData;
    }

    /// <summary>
    ///     DeleteFeedback expense history by id
    /// </summary>
    /// <param name="expenseHistoryId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteExpenseHistory(int expenseHistoryId)
    {
        var expenseHistoryFound = await _context.ExpenseHistories
            .FindAsync(expenseHistoryId.ToString());
        if (expenseHistoryFound == null)
            return false;
        _context.ExpenseHistories.Remove(expenseHistoryFound);
        await _context.SaveChangesAsync();
        return true;
    }
}