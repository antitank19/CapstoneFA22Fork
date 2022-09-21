using Application.IRepository;
using Application.IService;
using Domain.EntitiesForManagement;

namespace Application.Service;

public class BuildingService : IBuildingService
{
    private readonly IRepositoryWrapper reposities;

    public BuildingService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
    //Demo
    public IQueryable<Building> GetAllDemo()
    {
        return reposities.Buildings.GetBuildingList();
    }
}