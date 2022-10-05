using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IFeedbackTypeService
{
    public Task<IEnumerable<FeedbackType?>> GetFeedbackTypeList();
    public Task<FeedbackType?> GetFeedbackTypeById(int feedbackTypeId);
    public Task<FeedbackType?> AddFeedbackType(FeedbackType feedbackType);
    public Task<FeedbackType?> UpdateFeedbackType(FeedbackType feedbackType);
    public Task<bool> DeleteFeedbackType(int feedbackTypeId);
}