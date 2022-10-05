using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IInvoiceRepository
{
    public IQueryable<Invoice> GetInvoiceList();
    public IQueryable<Invoice> GetInvoiceDetail(int invoiceId);
    public Task<Invoice> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
}