using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RentEntityService : IRentEntityService
{
    private readonly IRepositoryWrapper reposities;

    public RentEntityService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}