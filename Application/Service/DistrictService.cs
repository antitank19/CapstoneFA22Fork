using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class DistrictService : IDistrictService
{
    private readonly IReposityWrapper reposities;

    public DistrictService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}