using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IExpenseRepository
    {
        public IQueryable<Expense> GetList();
        public IQueryable<Expense> GetDetail(int Id);
        public Task<Expense> Add(Expense entity);
        public Task<Expense> Update(Expense entity);
        public Task<bool> Delete(int id);
    }
}