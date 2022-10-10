using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class InvoiceHistoryService : IInvoiceHistoryService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceHistoryService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<InvoiceHistory> GetInvoiceHistoryList()
    {
        return _repositoryWrapper.InvoiceHistories.GetInvoiceHistoryList();
    }

    public async Task<InvoiceHistory?> GetInvoiceHistoryById(int invoiceHistoryId)
    {
        return await _repositoryWrapper.InvoiceHistories.GetInvoiceHistoryDetail(invoiceHistoryId)
            .FirstOrDefaultAsync();
    }

    public async Task<InvoiceHistory?> AddInvoiceHistory(InvoiceHistory invoiceHistory)
    {
        return await _repositoryWrapper.InvoiceHistories.AddInvoiceHistory(invoiceHistory);
    }

    public async Task<InvoiceHistory?> UpdateInvoiceHistory(InvoiceHistory invoiceHistory)
    {
        return await _repositoryWrapper.InvoiceHistories.UpdateInvoiceHistory(invoiceHistory);
    }

    public async Task<bool> DeleteInvoiceHistory(int invoiceHistoryId)
    {
        return await _repositoryWrapper.InvoiceHistories.DeleteInvoiceHistory(invoiceHistoryId);
    }
}