using Domain.EntitiesForManagement;

namespace Application.IRepository
{
    public interface IFeedbackTypeRepository
    {
        public IQueryable<FeedbackType> GetList();
        public IQueryable<FeedbackType> GetDetail(int Id);
        public Task<FeedbackType> Add(FeedbackType entity);
        public Task<FeedbackType> Update(FeedbackType entity);
        public Task<bool> Delete(int id);
    }
}