using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class AccountService : IAccountService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AccountService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Account> GetAccountList()
    {
        return _repositoryWrapper.Accounts.GetAccountList();
    }

    public async Task<Account?> GetAccountById(int accountId)
    {
        return await _repositoryWrapper.Accounts.GetAccountDetail(accountId)
            .FirstOrDefaultAsync();
    }

    public async Task<Account?> AddAccount(Account account)
    {
        return await _repositoryWrapper.Accounts.AddAccount(account);
    }

    public async Task<Account?> UpdateAccount(Account account)
    {
        return await _repositoryWrapper.Accounts.UpdateAccount(account);
    }

    public async Task<bool> ToggleAccountStatus(int accountId)
    {
        return await _repositoryWrapper.Accounts.ToggleAccount(accountId);
    }

    public async Task<bool> DeleteAccount(int accountId)
    {
        return await _repositoryWrapper.Accounts.DeleteAccount(accountId);
    }

    public async Task<Account> Login(string username, string password)
    {
        var list = _repositoryWrapper.Accounts.GetAccountList();
        var logined = await list.SingleOrDefaultAsync(e => e.Username == username && e.Password == password);
        if (logined != null) logined.Role = await _repositoryWrapper.Roles.GetRoleDetail(logined.RoleId);
        return logined;
    }

    public async Task<Account?> AccountLogin(Account account)
    {
        return await _repositoryWrapper.Accounts.GetAccount(account)
            .FirstOrDefaultAsync();
    }
}