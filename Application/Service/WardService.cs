using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class WardService : IWardService
{
    private readonly IRepositoryWrapper reposities;

    public WardService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}