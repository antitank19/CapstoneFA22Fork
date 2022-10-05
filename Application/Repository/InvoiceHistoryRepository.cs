using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class InvoiceHistoryRepository : IInvoiceHistoryRepository
{
    private readonly ApplicationContext _context;

    public InvoiceHistoryRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all invoice history
    /// </summary>
    /// <returns></returns>
    public IQueryable<InvoiceHistory> GetInvoiceHistoryList()
    {
        return _context.InvoiceHistories.AsQueryable();
    }

    /// <summary>
    ///     Get invoice detail by id
    /// </summary>
    /// <param name="invoiceHistoryId"></param>
    /// <returns></returns>
    public IQueryable<InvoiceHistory> GetInvoiceHistoryDetail(int invoiceHistoryId)
    {
        return _context.InvoiceHistories
            .Where(x => x.InvoiceHistoryId == invoiceHistoryId);
    }

    /// <summary>
    ///     Add new invoice history
    /// </summary>
    /// <param name="invoiceHistory"></param>
    /// <returns></returns>
    public async Task<InvoiceHistory> AddInvoiceHistory(InvoiceHistory invoiceHistory)
    {
        await _context.InvoiceHistories.AddAsync(invoiceHistory);
        await _context.SaveChangesAsync();
        return invoiceHistory;
    }

    /// <summary>
    ///     Update invoice history by id
    /// </summary>
    /// <param name="invoiceHistory"></param>
    /// <returns></returns>
    public async Task<InvoiceHistory?> UpdateInvoiceHistory(InvoiceHistory? invoiceHistory)
    {
        var invoiceHistoryData = await _context.InvoiceHistories
            .FirstOrDefaultAsync(x => x.InvoiceHistoryId == invoiceHistory!.InvoiceHistoryId);
        if (invoiceHistoryData == null)
            return null;

        invoiceHistoryData.Detail = invoiceHistory?.Detail ?? invoiceHistoryData.Detail;
        invoiceHistoryData.Image = invoiceHistory?.Image ?? invoiceHistoryData.Image;
        invoiceHistoryData.Name = invoiceHistory?.Name ?? invoiceHistoryData.Name;
        invoiceHistoryData.Status = invoiceHistory?.Status ?? invoiceHistoryData.Status;
        invoiceHistoryData.UpdatedDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return invoiceHistoryData;
    }

    /// <summary>
    ///     Delete invoice history by id
    /// </summary>
    /// <param name="invoiceHistoryId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteInvoiceHistory(int invoiceHistoryId)
    {
        var invoiceHistoryFound = await _context.InvoiceHistories
            .FindAsync(invoiceHistoryId.ToString());
        if (invoiceHistoryFound == null)
            return false;
        _context.InvoiceHistories.Remove(invoiceHistoryFound);
        await _context.SaveChangesAsync();
        return true;
    }
}