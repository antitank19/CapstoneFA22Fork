using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class TransactionRepository : ITransactionRepository
{
    public IQueryable<Transaction> GetTransactionList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Transaction> GetTransactionDetail(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> AddTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> UpdateTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }
}