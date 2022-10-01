using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class BuildingRepository : IBuildingRepository
{
    private readonly ApplicationContext context;

    public BuildingRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Building> GetBuildingList()
    {
        return context.Buildings;
    }


    public IQueryable<Building> GetBuildingByAppartment(Appartment ward)
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

    public IQueryable<Building> GetBuildingListByName(string name)
    {
        throw new NotImplementedException();
    }
}