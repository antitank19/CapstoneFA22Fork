using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class InvoiceService : IInvoiceService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Invoice> GetInvoiceList()
    {
        return _repositoryWrapper.Invoices.GetInvoiceList();
    }

    public async Task<Invoice?> GetInvoiceById(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceDetail(invoiceId)
            .FirstOrDefaultAsync();
    }

    public async Task<Invoice?> AddInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.AddInvoice(invoice);
    }

    public async Task<Invoice?> UpdateInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.UpdateInvoice(invoice);
    }

    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.DeleteInvoice(invoiceId);
    }
}