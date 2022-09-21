using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class CityService : ICityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CityService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}