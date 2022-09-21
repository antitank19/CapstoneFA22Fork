using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RentEntityService : IRentEntityService
{
    private readonly IReposityWrapper reposities;

    public RentEntityService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}