using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class UniversityRepository : IUniversityRepository
{
    private readonly ApplicationContext context;

    public UniversityRepository(ApplicationContext context)
    {
        this.context = context;
    }

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