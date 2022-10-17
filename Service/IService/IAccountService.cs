using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IAccountService
{
    public IQueryable<Account> GetAccountList();
    public Task<Account?> GetAccountById(int accountId);
    public Task<Account?> AddAccount(Account account);
    public Task<Account?> UpdateAccount(Account account);
    public Task<bool> ToggleAccountStatus(int accountId);
    public Task<bool> DeleteAccount(int accountId);
    public Task<Account> Login(string username, string password);
    public Task<Account?> AccountLogin(string username, string password);
    public Task<Account?> GetSupervisorAccount(int accountId);
}