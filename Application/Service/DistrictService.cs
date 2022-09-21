using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class DistrictService : IDistrictService
{
    private readonly IRepositoryWrapper reposities;

    public DistrictService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}