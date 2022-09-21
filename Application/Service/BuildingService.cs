using Application.IRepository;
using Application.IService;
using Domain.EntitiesForManagement;

namespace Application.Service;

public class BuildingService : IBuildingService
{
    private readonly IReposityWrapper reposities;

    public BuildingService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
    //Demo
    public IQueryable<Building> GetAllDemo()
    {
        return reposities.Buildings.GetBuildingList();
    }
}