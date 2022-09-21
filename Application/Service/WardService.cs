using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class WardService : IWardService
{
    private readonly IReposityWrapper reposities;

    public WardService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}