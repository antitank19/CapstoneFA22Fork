using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IInvoiceHistoryRepository
{
    public IQueryable<InvoiceHistory> GetInvoiceHistoryList();

    // TODO : Get invoice history based on room id
    public IQueryable<InvoiceHistory> GetInvoiceHistoryDetail(int invoiceHistoryId);
    public Task<InvoiceHistory> AddInvoiceHistory(InvoiceHistory invoiceHistory);
    public Task<InvoiceHistory?> UpdateInvoiceHistory(InvoiceHistory invoiceHistory);
    public Task<bool> DeleteInvoiceHistory(int invoiceHistoryId);
}