using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class CityService : ICityService
{
    private readonly IReposityWrapper reposities;

    public CityService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}