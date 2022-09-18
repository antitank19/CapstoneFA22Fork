using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class UniversityRepository : IUniversityRepository
{
    public IQueryable<University> GetUniversityList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<University> GetUniversityListByName(string universityName)
    {
        throw new NotImplementedException();
    }

    public Task<University> GetUniversityDetail(int universityId)
    {
        throw new NotImplementedException();
    }

    public Task<University> AddUniversity(University university)
    {
        throw new NotImplementedException();
    }

    public Task<University> UpdateUniversity(University university)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUniversity(int universityId)
    {
        throw new NotImplementedException();
    }
}