using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class OwnerService : IOwnerService
{
    private readonly IRepositoryWrapper reposities;

    public OwnerService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}