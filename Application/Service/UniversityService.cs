using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class UniversityService : IUniversityService
{
    private readonly IRepositoryWrapper reposities;

    public UniversityService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}