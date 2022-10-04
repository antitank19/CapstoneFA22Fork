using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IMajorRepository
    {
        public IQueryable<Major> GetList();
        public IQueryable<Major> GetDetail(int Id);
        public Task<Major> Add(Major entity);
        public Task<Major> Update(Major entity);
        public Task<bool> Delete(int id);
    }
}