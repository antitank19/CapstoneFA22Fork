using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class BillRepository : IBillRepository
{
    private readonly ApplicationContext _context;

    public BillRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get a list of all bills
    /// </summary>
    /// <returns></returns>
    public IQueryable<Bill> GetBillList()
    {
        return _context.Bills.AsQueryable();
    }

    /// <summary>
    ///     Get bill detail using bill id
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    public IQueryable<Bill> GetBillDetail(int billId)
    {
        return _context.Bills
            .Where(x => x.BillId == billId);
    }

    /// <summary>
    ///     AddExpenseHistory new bill to user
    /// </summary>
    /// <param name="bill"></param>
    /// <returns></returns>
    public async Task<Bill> AddBill(Bill bill)
    {
        // TODO : Check adding bill to each user in the room !! Basic for now
        await _context.Bills.AddAsync(bill);
        await _context.SaveChangesAsync();
        return bill;
    }

    /// <summary>
    ///     UpdateExpenseHistory bill
    /// </summary>
    /// <param name="bill"></param>
    /// <returns></returns>
    public async Task<Bill?> UpdateBill(Bill? bill)
    {
        // TODO : Check updating bill to each user in the room !! Basic for now
        var billData = await _context.Bills
            //.Include(x => x.Invoice.Contract.Renter.RenterId)
            .FirstOrDefaultAsync(x => x.BillId == bill!.BillId);

        if (billData == null)
            return null;

        billData.Detail = bill?.Detail ?? billData.Detail;
        billData.Name = bill?.Name ?? billData.Name;
        billData.Status = bill?.Status ?? billData.Status;
        billData.DueDate = bill?.DueDate ?? billData.DueDate;

        await _context.SaveChangesAsync();

        return billData;
    }

    /// <summary>
    ///     DeleteExpenseHistory bill using id
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteBill(int billId)
    {
        var billFound = await _context.Bills
            .FirstOrDefaultAsync(x => x.BillId == billId);
        if (billFound == null)
            return false;
        _context.Bills.Remove(billFound);
        await _context.SaveChangesAsync();
        return true;
    }
}