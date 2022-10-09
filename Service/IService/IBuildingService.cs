using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IBuildingService
{
    public IQueryable<Building> GetBuildingList();
    public Task<Building?> GetBuildingById(int buildingId);
    public Task<Building?> AddBuilding(Building building);
    public Task<Building?> UpdateBuilding(Building building);
    public Task<bool> DeleteBuilding(int buildingId);
}