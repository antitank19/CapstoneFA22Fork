using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoleService : IRoleService
{
    private readonly IRepositoryWrapper reposities;

    public RoleService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}