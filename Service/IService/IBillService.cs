using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IBillService
{
    public IQueryable<Bill> GetBillList();
    public Task<Bill?> GetBillById(int billId);
    public Task<Bill?> AddBill(Bill bill);
    public Task<Bill?> UpdateBill(Bill bill);
    public Task<bool> DeleteBill(int billId);
}