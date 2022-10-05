using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRequestTypeService
{
    public Task<IEnumerable<RequestType?>> GetRequestTypeList();
    public Task<RequestType?> GetRequestTypeById(int requestTypeId);
    public Task<RequestType?> AddRequestType(RequestType requestType);
    public Task<RequestType?> UpdateRequestType(RequestType requestType);
    public Task<bool> DeleteRequestType(int requestTypeId);
}