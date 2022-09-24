using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class OwnerService : IOwnerService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public OwnerService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}