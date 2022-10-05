using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class UniversityRepository : IUniversityRepository
{
    private readonly ApplicationContext _context;

    public UniversityRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all universities
    /// </summary>
    /// <returns></returns>
    public IQueryable<University> GetUniversityList()
    {
        return _context.University.AsQueryable();
    }

    /// <summary>
    ///     Get university containing query string name
    /// </summary>
    /// <param name="universityName"></param>
    /// <returns></returns>
    public IQueryable<University> GetUniversityListByName(string universityName)
    {
        return _context.University
            .Where(x => x.UniversityName.Contains(universityName));
    }

    /// <summary>
    ///     Get university by id
    /// </summary>
    /// <param name="universityId"></param>
    /// <returns></returns>
    public IQueryable<University> GetUniversityDetail(int universityId)
    {
        return _context.University
            .Where(x => x.UniversityId == universityId);
    }

    /// <summary>
    ///     AddFeedback new university
    /// </summary>
    /// <param name="university"></param>
    /// <returns></returns>
    public async Task<University> AddUniversity(University university)
    {
        await _context.University.AddAsync(university);
        await _context.SaveChangesAsync();
        return university;
    }

    /// <summary>
    ///     UpdateFeedback university
    /// </summary>
    /// <param name="university"></param>
    /// <returns></returns>
    public async Task<University?> UpdateUniversity(University? university)
    {
        var universityData = await _context.University
            .FirstOrDefaultAsync(x => x.UniversityId == university!.UniversityId);
        if (universityData == null)
            return null;

        universityData.UniversityName = university?.UniversityName ?? universityData.UniversityName;
        universityData.Address = university?.Address ?? universityData.Address;
        universityData.Description = university?.Description ?? universityData.Description;
        universityData.Image = university?.Image ?? universityData.Image;
        universityData.Status = university?.Status ?? universityData.Status;

        await _context.SaveChangesAsync();

        return university;
    }

    /// <summary>
    ///     DeleteFeedback university
    /// </summary>
    /// <param name="universityId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteUniversity(int universityId)
    {
        var universityFound = await _context.University
            .FindAsync(universityId.ToString());
        if (universityFound == null)
            return false;
        _context.University.Remove(universityFound);
        await _context.SaveChangesAsync();
        return true;
    }
}