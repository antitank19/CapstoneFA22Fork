using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class OwnerService : IOwnerService
{
    private readonly IReposityWrapper reposities;

    public OwnerService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}