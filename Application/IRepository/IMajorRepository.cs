using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IMajorRepository
{
    public IQueryable<Major> GetMajorList();
    public IQueryable<Major> GetMajorDetail(int majorId);
    public Task<Major> AddMajor(Major major);
    public Task<Major?> UpdateMajor(Major major);
    public Task<bool> DeleteMajor(int majorId);
}