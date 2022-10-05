using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IBillRepository
{
    public IQueryable<Bill> GetBillList();
    public IQueryable<Bill> GetBillDetail(int billId);
    public Task<Bill> AddBill(Bill bill);
    public Task<Bill?> UpdateBill(Bill bill);
    public Task<bool> DeleteBill(int id);
}