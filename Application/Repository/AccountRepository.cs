using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext context;

    public AccountRepository(ApplicationContext context)
    {
        this.context = context;
    }
    
    /// <summary>
    /// Get list of all account available in the database
    /// </summary>
    /// <returns></returns>

    public IQueryable<Account> GetAccountList()
    {
        return context.Accounts;
    }

    /// <summary>
    /// Get a list of account containing the query string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Account> GetAccountListContainName(string name)
    {
        return context.Accounts.Where(a => string.Equals(a.Username, name,
            StringComparison.CurrentCultureIgnoreCase));
    }

    public IQueryable<Account> GetAccount(int accountId)
    {
        return context.Accounts
            .Where(a => a.AccountId == accountId);
    }

    /// <summary>
    /// Add new account
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account> AddAccount(Account account)
    {
        await context.Accounts.AddAsync(account);
        await context.SaveChangesAsync();
        return account;
    }

    /// <summary>
    /// Update account status
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account?> UpdateAccount(Account account)
    {
        try
        {
            var accountData = await context.Accounts
                .FirstOrDefaultAsync(x => x.AccountId == account.AccountId);
            if (accountData != null)
            {
                accountData.Email ??= account.Email;
                accountData.Password ??= account.Password;
                accountData.Phone ??= account.Phone;
                await context.SaveChangesAsync();
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return account;
    }

    /// <summary>
    /// Toggle account status
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleAccount(int accountId)
    {
        var accountFound = await context.Accounts
            .FirstOrDefaultAsync(x => x.AccountId == accountId);
        if (accountFound == null)
            return false;
        _ = accountFound.Status == !accountFound.Status;
        await context.SaveChangesAsync();
        return true;
    }
   
}