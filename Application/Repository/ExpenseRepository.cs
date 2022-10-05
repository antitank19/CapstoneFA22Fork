using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ExpenseRepository : IExpenseRepository
{
    private readonly ApplicationContext _context;

    public ExpenseRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all expenses
    /// </summary>
    /// <returns></returns>
    public IQueryable<Expense> GetExpenseList()
    {
        return _context.Expenses.AsQueryable();
    }

    /// <summary>
    ///     Get expense by id
    /// </summary>
    /// <param name="expenseId"></param>
    /// <returns></returns>
    public IQueryable<Expense> GetExpenseDetail(int expenseId)
    {
        return _context.Expenses
            .Where(x => x.ExpenseId == expenseId);
    }

    /// <summary>
    ///     AddFeedback new expense to database
    /// </summary>
    /// <param name="expense"></param>
    /// <returns></returns>
    public async Task<Expense> AddExpense(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    /// <summary>
    ///     UpdateFeedback Expense in database
    /// </summary>
    /// <param name="expense"></param>
    /// <returns></returns>
    public async Task<Expense?> UpdateExpense(Expense? expense)
    {
        var expenseData = await _context.Expenses
            .FirstOrDefaultAsync(x => x.ExpenseId == expense!.ExpenseId);
        if (expenseData == null)
            return null;

        expenseData.Name = expense?.Name ?? expenseData.Name;
        expenseData.ExpenseTypeId = expense?.ExpenseTypeId ?? expenseData.ExpenseTypeId;
        expenseData.SupervisorId = expense?.SupervisorId ?? expenseData.SupervisorId;

        await _context.SaveChangesAsync();
        return expenseData;
    }

    /// <summary>
    ///     DeleteFeedback Expense by Id
    /// </summary>
    /// <param name="expenseId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteExpense(int expenseId)
    {
        var expenseFound = await _context.ExpenseHistories
            .FindAsync(expenseId.ToString());
        if (expenseFound == null)
            return false;
        _context.ExpenseHistories.Remove(expenseFound);
        await _context.SaveChangesAsync();
        return true;
    }
}