using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRequestTypeRepository
{
    public IQueryable<RequestType> GetRequestTypeList();
    public IQueryable<RequestType> GetRequestTypeDetail(int requestTypeId);
    public Task<RequestType> AddRequestType(RequestType requestType);
    public Task<RequestType?> UpdateRequestType(RequestType requestType);
    public Task<bool> DeleteRequestType(int requestTypeId);
    public Task<bool> ToggleRequestTypeStatus(int requestTypeId);
}