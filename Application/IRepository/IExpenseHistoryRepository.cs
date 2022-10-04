using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IExpenseHistoryRepository
    {
        public IQueryable<ExpenseHistory> GetList();
        public IQueryable<ExpenseHistory> GetDetail(int Id);
        public Task<ExpenseHistory> Add(ExpenseHistory entity);
        public Task<ExpenseHistory> Update(ExpenseHistory entity);
        public Task<bool> Delete(int id);
    }
}