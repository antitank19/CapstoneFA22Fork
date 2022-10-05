using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IInvoiceHistoryService
{
    public Task<IEnumerable<InvoiceHistory?>> GetInvoiceHistoryList();
    public Task<InvoiceHistory?> GetInvoiceHistoryById(int invoiceHistoryId);
    public Task<InvoiceHistory?> AddInvoiceHistory(InvoiceHistory invoiceHistory);
    public Task<InvoiceHistory?> UpdateInvoiceHistory(InvoiceHistory invoiceHistory);
    public Task<bool> DeleteInvoiceHistory(int invoiceHistoryId);
}