using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class BillRepository : IBillRepository
{
    private readonly ApplicationContext context;

    public BillRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Bill> GetBillList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Bill> GetBillDetail(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<Bill> AddBill(Bill transaction)
    {
        throw new NotImplementedException();
    }

    public Task<Bill> UpdateBill(Bill transaction)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBill(int transactionId)
    {
        throw new NotImplementedException();
    }
}