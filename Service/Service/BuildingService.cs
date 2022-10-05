using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class BuildingService : IBuildingService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public BuildingService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Building?>> GetBuildingList()
    {
        return await _repositoryWrapper.Buildings.GetBuildingList()
            .ToListAsync();
    }

    public async Task<Building?> GetBuildingById(int buildingId)
    {
        return await _repositoryWrapper.Buildings.GetBuildingDetail(buildingId)
            .FirstOrDefaultAsync();
    }

    public async Task<Building?> AddBuilding(Building building)
    {
        return await _repositoryWrapper.Buildings.AddBuilding(building);
    }

    public async Task<Building?> UpdateBuilding(Building building)
    {
        return await _repositoryWrapper.Buildings.UpdateBuilding(building);
    }

    public async Task<bool> DeleteBuilding(int buildingId)
    {
        return await _repositoryWrapper.Buildings.DeleteBuilding(buildingId);
    }
}