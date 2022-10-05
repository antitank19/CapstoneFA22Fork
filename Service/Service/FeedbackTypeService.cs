using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class FeedbackTypeService : IFeedbackTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FeedbackTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<FeedbackType?>> GetFeedbackTypeList()
    {
        return await _repositoryWrapper.FeedbackTypes.GetFeedbackTypeList()
            .ToListAsync();
    }

    public async Task<FeedbackType?> GetFeedbackTypeById(int feedbackTypeId)
    {
        return await _repositoryWrapper.FeedbackTypes.GetFeedbackTypeDetail(feedbackTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<FeedbackType?> AddFeedbackType(FeedbackType feedbackType)
    {
        return await _repositoryWrapper.FeedbackTypes.AddFeedbackType(feedbackType);
    }

    public async Task<FeedbackType?> UpdateFeedbackType(FeedbackType feedbackType)
    {
        return await _repositoryWrapper.FeedbackTypes.UpdateFeedbackType(feedbackType);
    }

    public async Task<bool> DeleteFeedbackType(int feedbackTypeId)
    {
        return await _repositoryWrapper.FeedbackTypes.DeleteFeedbackType(feedbackTypeId);
    }
}