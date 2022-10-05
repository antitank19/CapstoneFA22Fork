using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IFeedbackRepository
{
    public IQueryable<Feedback> GetFeedbackList();
    public IQueryable<Feedback> GetFeedbackDetail(int feedbackId);
    public Task<Feedback> AddFeedback(Feedback feedback);
    public Task<Feedback?> UpdateFeedback(Feedback feedback);
    public Task<bool> DeleteFeedback(int feedbackId);
}