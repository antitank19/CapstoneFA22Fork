using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IUniversityService
{
    public Task<IEnumerable<University?>> GetUniversityList();
    public Task<University?> GetUniversityById(int universityId);
    public Task<University?> AddUniversity(University university);
    public Task<University?> UpdateUniversity(University university);
    public Task<bool> DeleteUniversity(int universityId);
}