using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IAccountRepository
{
    public IQueryable<Account> GetAccountList();
    public IQueryable<Account> GetAccountListContainName(string name);
    public IQueryable<Account> GetAccountDetail(int accountId);
    public Task<Account> AddAccount(Account account);
    public Task<Account?> UpdateAccount(Account account);
    public Task<bool> ToggleAccount(int accountId);
}