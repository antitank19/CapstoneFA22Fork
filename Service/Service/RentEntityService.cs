using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class RentEntityService : IRentEntityService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RentEntityService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}