using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface ITransactionRepository
{
    public IQueryable<Transaction> GetTransactionList();
    public IQueryable<Transaction> GetTransactionDetail(int transactionId);
    public Task<Transaction> AddTransaction(Transaction transaction);
    public Task<Transaction> UpdateTransaction(Transaction transaction);
    public Task<bool> DeleteTransaction(int transactionId);
}