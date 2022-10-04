using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IInvoiceRepository
    {
        public IQueryable<Invoice> GetList();
        public IQueryable<Invoice> GetDetail(int Id);
        public Task<Invoice> Add(Invoice entity);
        public Task<Invoice> Update(Invoice entity);
        public Task<bool> Delete(int id);
    }
}