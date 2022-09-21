using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class UniversityService : IUniversityService
{
    private readonly IReposityWrapper reposities;

    public UniversityService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}