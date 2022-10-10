using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IInvoiceService
{
    public IQueryable<Invoice> GetInvoiceList();

    // TODO : Get invoice based on room id
    public Task<Invoice?> GetInvoiceById(int invoiceId);
    public Task<Invoice?> AddInvoice(Invoice invoice);
    public Task<Invoice?> UpdateInvoice(Invoice invoice);
    public Task<bool> DeleteInvoice(int invoiceId);
}