using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IUniversityRepository
{
    public IQueryable<University> GetUniversityList();
    public IQueryable<University> GetUniversityListByName(string universityName);
    public IQueryable<University> GetUniversityDetail(int universityId);
    public Task<University> AddUniversity(University university);
    public Task<University?> UpdateUniversity(University university);
    public Task<bool> DeleteUniversity(int universityId);
}