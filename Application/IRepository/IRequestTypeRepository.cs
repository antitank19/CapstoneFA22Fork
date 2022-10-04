using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IRequestTypeRepository
    {
        public IQueryable<RequestType> GetList();
        public IQueryable<RequestType> GetDetail(int Id);
        public Task<RequestType> Add(RequestType entity);
        public Task<RequestType> Update(RequestType entity);
        public Task<bool> Delete(int id);
    }
}