using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationContext _context;

    public InvoiceRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all invoices
    /// </summary>
    /// <returns></returns>
    public IQueryable<Invoice> GetInvoiceList()
    {
        return _context.Invoices.AsQueryable();
    }

    /// <summary>
    ///     Get invoice by id
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public IQueryable<Invoice> GetInvoiceDetail(int invoiceId)
    {
        return _context.Invoices
            .Where(x => x.InvoiceId == invoiceId);
    }

    /// <summary>
    ///     Add new invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice> AddInvoice(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    /// <summary>
    ///     Update invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice?> UpdateInvoice(Invoice? invoice)
    {
        var invoiceData = await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoice!.InvoiceId);
        if (invoiceData == null)
            return null;

        invoiceData.Detail = invoice?.Detail ?? invoiceData.Detail;
        invoiceData.Name = invoice?.Name ?? invoiceData.Name;
        invoiceData.Status = invoice?.Status ?? invoiceData.Status;
        // TODO : Check if wanted to change invoice destination

        await _context.SaveChangesAsync();
        return invoiceData;
    }

    /// <summary>
    ///     Delete invoice
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        var invoiceFound = await _context.Invoices
            .FindAsync(invoiceId.ToString());
        if (invoiceFound == null)
            return false;
        _context.Invoices.Remove(invoiceFound);
        await _context.SaveChangesAsync();
        return true;
    }
}