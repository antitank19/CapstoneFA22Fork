using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class AreaService : IAreaService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AreaService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Area?>> GetAreaList()
    {
        return await _repositoryWrapper.Areas.GetAreaList()
            .ToListAsync();
    }

    public async Task<Area?> GetAreaById(int areaId)
    {
        return await _repositoryWrapper.Areas.GetAreaDetail(areaId)
            .FirstOrDefaultAsync();
    }

    public async Task<Area?> AddArea(Area area)
    {
        return await _repositoryWrapper.Areas.AddArea(area);
    }

    public async Task<Area?> UpdateArea(Area area)
    {
        return await _repositoryWrapper.Areas.UpdateArea(area);
    }

    public async Task<bool> ToggleAreaStatus(int areaId)
    {
        return await _repositoryWrapper.Areas.ToggleArea(areaId);
    }

    public async Task<bool> DeleteArea(int areaId)
    {
        return await _repositoryWrapper.Areas.DeleteArea(areaId);
    }
}