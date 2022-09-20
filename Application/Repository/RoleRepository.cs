using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationContext context;

    public RoleRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Role> GetRoleList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Role> GetRoleDetail(int roleId)
    {
        throw new NotImplementedException();
    }

    public Task<Role> AddRole(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<Role> UpdateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRole(int roleId)
    {
        throw new NotImplementedException();
    }
}