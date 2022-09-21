using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationContext context;

    public TransactionRepository(ApplicationContext context)
    {
        this.context = context;
    }

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