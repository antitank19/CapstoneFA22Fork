using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class BuildingService : IBuildingService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public BuildingService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
    
    public object GetList()
    {
        return _repositoryWrapper.Buildings.GetBuildingList();
    }
}