using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class RequestService : IRequestService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RequestService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Request> GetRequestList()
    {
        return _repositoryWrapper.Requests.GetRequestList();
    }

    public async Task<Request?> GetRequestById(int requestId)
    {
        return await _repositoryWrapper.Requests.GetRequestDetail(requestId)
            .FirstOrDefaultAsync();
    }

    public async Task<Request?> AddRequest(Request request)
    {
        return await _repositoryWrapper.Requests.AddRequest(request);
    }

    public async Task<Request?> UpdateRequest(Request request)
    {
        return await _repositoryWrapper.Requests.UpdateRequest(request);
    }

    public async Task<bool> DeleteRequest(int requestId)
    {
        return await _repositoryWrapper.Requests.DeleteRequest(requestId);
    }
}