using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IAccountService
{
    public Task<IEnumerable<Account?>> GetAccountList();
    public Task<Account?> GetAccountById(int accountId);
    public Task<Account?> AddAccount(Account account);
    public Task<Account?> UpdateAccount(Account account);
    public Task<bool> ToggleAccountStatus(int accountId);
    public Task<bool> DeleteAccount(int accountId);
}