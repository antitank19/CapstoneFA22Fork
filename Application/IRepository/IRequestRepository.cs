using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IRequestRepository
    {
        public IQueryable<Request> GetList();
        public IQueryable<Request> GetDetail(int Id);
        public Task<Request> Add(Request entity);
        public Task<Request> Update(Request entity);
        public Task<bool> Delete(int id);
    }
}