using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class CityService : ICityService
{
    private readonly IRepositoryWrapper reposities;

    public CityService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}