using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext _context;

    public AccountRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get list of all account available in the database
    /// </summary>
    /// <returns></returns>
    public IQueryable<Account> GetAccountList()
    {
        return _context.Accounts.AsQueryable();
    }

    /// <summary>
    ///     Get a list of account containing the query string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccountListContainName(string name)
    {
        return _context.Accounts.Where(a => string.Equals(a.Username, name,
            StringComparison.CurrentCultureIgnoreCase));
    }

    /// <summary>
    ///     Get account details by Id
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccountDetail(int accountId)
    {
        return _context.Accounts
            .Where(a => a.AccountId == accountId);
    }

    /// <summary>
    ///     AddExpenseHistory new account
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account> AddAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return account;
    }

    /// <summary>
    ///     UpdateExpenseHistory account status
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account?> UpdateAccount(Account? account)
    {
        var accountData = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == account!.AccountId);
        if (accountData == null)
            return null;
        accountData.Email = account?.Email ?? accountData.Email;
        accountData.Password = account?.Password ?? accountData.Password;
        accountData.Phone = account?.Phone ?? accountData.Phone;
        accountData.Username = account?.Username ?? accountData.Username;
        accountData.RoleId = account?.RoleId ?? accountData.RoleId;
        await _context.SaveChangesAsync();

        return accountData;
    }

    /// <summary>
    ///     Toggle account status
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleAccount(int accountId)
    {
        var accountFound = await _context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == accountId);
        if (accountFound == null)
            return false;
        _ = accountFound.Status == !accountFound.Status;
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     DeleteExpenseHistory account by Id
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAccount(int accountId)
    {
        var accountFound = await _context.Accounts
            .FindAsync(accountId.ToString());
        if (accountFound == null)
            return false;
        _context.Accounts.Remove(accountFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Get account based on username and password
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccount(string username, string password)
    {
        return _context.Accounts
            .Where(a => a.Username == username && a.Password == password)
            .Include(b => b.Role);
    }
}