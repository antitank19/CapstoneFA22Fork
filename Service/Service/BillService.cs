using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class BillService : IBillService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public BillService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Bill> GetBillList()
    {
        return _repositoryWrapper.Bills.GetBillList();
    }

    public async Task<Bill?> GetBillById(int billId)
    {
        return await _repositoryWrapper.Bills.GetBillDetail(billId)
            .FirstOrDefaultAsync();
    }

    public async Task<Bill?> AddBill(Bill bill)
    {
        return await _repositoryWrapper.Bills.AddBill(bill);
    }

    public async Task<Bill?> UpdateBill(Bill bill)
    {
        return await _repositoryWrapper.Bills.UpdateBill(bill);
    }

    public async Task<bool> DeleteBill(int billId)
    {
        return await _repositoryWrapper.Bills.DeleteBill(billId);
    }
}