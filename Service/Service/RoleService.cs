using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class RoleService : IRoleService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoleService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}