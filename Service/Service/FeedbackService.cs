using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class FeedbackService : IFeedbackService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FeedbackService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Feedback?>> GetFeedbackList()
    {
        return await _repositoryWrapper.Feedbacks.GetFeedbackList()
            .ToListAsync();
    }

    public async Task<Feedback?> GetFeedbackById(int feedbackId)
    {
        return await _repositoryWrapper.Feedbacks.GetFeedbackDetail(feedbackId)
            .FirstOrDefaultAsync();
    }

    public async Task<Feedback?> AddFeedback(Feedback feedback)
    {
        return await _repositoryWrapper.Feedbacks.AddFeedback(feedback);
    }

    public async Task<Feedback?> UpdateFeedback(Feedback feedback)
    {
        return await _repositoryWrapper.Feedbacks.UpdateFeedback(feedback);
    }

    public async Task<bool> DeleteFeedback(int feedbackId)
    {
        return await _repositoryWrapper.Feedbacks.DeleteFeedback(feedbackId);
    }
}