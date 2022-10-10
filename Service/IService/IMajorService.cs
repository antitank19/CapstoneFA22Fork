using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IMajorService
{
    public IQueryable<Major> GetMajorList();
    public Task<Major?> GetMajorById(int majorId);
    public Task<Major?> AddMajor(Major major);
    public Task<Major?> UpdateMajor(Major major);
    public Task<bool> DeleteMajor(int majorId);
}