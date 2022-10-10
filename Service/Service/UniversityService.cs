using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class UniversityService : IUniversityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public UniversityService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<University> GetUniversityList()
    {
        return _repositoryWrapper.Universities.GetUniversityList();
    }

    public async Task<University?> GetUniversityById(int universityId)
    {
        return await _repositoryWrapper.Universities.GetUniversityDetail(universityId)
            .FirstOrDefaultAsync();
    }

    public async Task<University?> AddUniversity(University university)
    {
        return await _repositoryWrapper.Universities.AddUniversity(university);
    }

    public async Task<University?> UpdateUniversity(University university)
    {
        return await _repositoryWrapper.Universities.UpdateUniversity(university);
    }

    public async Task<bool> DeleteUniversity(int universityId)
    {
        return await _repositoryWrapper.Universities.DeleteUniversity(universityId);
    }
}