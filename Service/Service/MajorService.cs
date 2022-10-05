using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class MajorService : IMajorService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public MajorService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Major?>> GetMajorList()
    {
        return await _repositoryWrapper.Majors.GetMajorList()
            .ToListAsync();
    }

    public async Task<Major?> GetMajorById(int majorId)
    {
        return await _repositoryWrapper.Majors.GetMajorDetail(majorId)
            .FirstOrDefaultAsync();
    }

    public async Task<Major?> AddMajor(Major major)
    {
        return await _repositoryWrapper.Majors.AddMajor(major);
    }

    public async Task<Major?> UpdateMajor(Major major)
    {
        return await _repositoryWrapper.Majors.UpdateMajor(major);
    }

    public async Task<bool> DeleteMajor(int majorId)
    {
        return await _repositoryWrapper.Majors.DeleteMajor(majorId);
    }
}