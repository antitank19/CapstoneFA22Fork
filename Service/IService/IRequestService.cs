using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRequestService
{
    public Task<IEnumerable<Request?>> GetRequestList();
    public Task<Request?> GetRequestById(int requestId);
    public Task<Request?> AddRequest(Request request);
    public Task<Request?> UpdateRequest(Request request);
    public Task<bool> DeleteRequest(int requestId);
}