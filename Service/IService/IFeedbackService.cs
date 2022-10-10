using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IFeedbackService
{
    public IQueryable<Feedback> GetFeedbackList();
    public Task<Feedback?> GetFeedbackById(int feedbackId);
    public Task<Feedback?> AddFeedback(Feedback feedback);
    public Task<Feedback?> UpdateFeedback(Feedback feedback);
    public Task<bool> DeleteFeedback(int feedbackId);
}