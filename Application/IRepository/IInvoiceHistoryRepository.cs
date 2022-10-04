using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IInvoiceHistoryRepository
    {
        public IQueryable<InvoiceHistory> GetList();
        public IQueryable<InvoiceHistory> GetDetail(int Id);
        public Task<InvoiceHistory> Add(InvoiceHistory entity);
        public Task<InvoiceHistory> Update(InvoiceHistory entity);
        public Task<bool> Delete(int id);
    }
}