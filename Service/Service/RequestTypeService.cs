using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class RequestTypeService : IRequestTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RequestTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<RequestType> GetRequestTypeList()
    {
        return _repositoryWrapper.RequestTypes.GetRequestTypeList();
    }

    public async Task<RequestType?> GetRequestTypeById(int requestTypeId)
    {
        return await _repositoryWrapper.RequestTypes.GetRequestTypeDetail(requestTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<RequestType?> AddRequestType(RequestType requestType)
    {
        return await _repositoryWrapper.RequestTypes.AddRequestType(requestType);
    }

    public async Task<RequestType?> UpdateRequestType(RequestType requestType)
    {
        return await _repositoryWrapper.RequestTypes.UpdateRequestType(requestType);
    }

    public async Task<bool> DeleteRequestType(int requestTypeId)
    {
        return await _repositoryWrapper.RequestTypes.DeleteRequestType(requestTypeId);
    }
}