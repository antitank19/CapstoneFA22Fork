using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IFeedbackRepository
    {
        public IQueryable<Feedback> GetList();
        public IQueryable<Feedback> GetDetail(int Id);
        public Task<Feedback> Add(Feedback entity);
        public Task<Feedback> Update(Feedback entity);
        public Task<bool> Delete(int id);
    }
}