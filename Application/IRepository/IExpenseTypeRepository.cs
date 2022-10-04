using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IExpenseTypeRepository
    {
        public IQueryable<ExpenseType> GetList();
        public IQueryable<ExpenseType> GetDetail(int Id);
        public Task<ExpenseType> Add(ExpenseType entity);
        public Task<ExpenseType> Update(ExpenseType entity);
        public Task<bool> Delete(int id);
    }
}