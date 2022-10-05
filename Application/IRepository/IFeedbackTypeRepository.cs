using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IFeedbackTypeRepository
{
    public IQueryable<FeedbackType> GetFeedbackTypeList();
    public IQueryable<FeedbackType> GetFeedbackTypeDetail(int feedbackTypeId);
    public Task<FeedbackType> AddFeedbackType(FeedbackType feedbackType);
    public Task<FeedbackType?> UpdateFeedbackType(FeedbackType feedbackType);
    public Task<bool> DeleteFeedbackType(int feedbackTypeId);
}