using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class BuildingRepository : IBuildingRepository
{
    public IQueryable<Building> GetBuildingList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Building> GetBuildingListByName(string name)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Building> GetBuildingByCity(City city)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Building> GetBuildingByDistrict(District district)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Building> GetBuildingByWard(Ward ward)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Building> GetBuildingDetail(int buildingId)
    {
        throw new NotImplementedException();
    }

    public Task<Building> AddBuilding(Building building)
    {
        throw new NotImplementedException();
    }

    public Task<Building> UpdateBuilding(Building building)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBuilding(Building building)
    {
        throw new NotImplementedException();
    }
}