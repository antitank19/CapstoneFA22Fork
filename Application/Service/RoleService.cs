using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoleService : IRoleService
{
    private readonly IReposityWrapper reposities;

    public RoleService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}