using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class RoleService : IRoleService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RoleService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Role?>> GetRoleList()
    {
        return await _repositoryWrapper.Roles.GetRoleList()
            .ToListAsync();
    }

    public async Task<Role?> GetRoleById(int roleId)
    {
        return await _repositoryWrapper.Roles.GetRoleDetail(roleId)
            .FirstOrDefaultAsync();
    }

    public async Task<Role?> AddRole(Role role)
    {
        return await _repositoryWrapper.Roles.AddRole(role);
    }

    public async Task<Role?> UpdateRole(Role role)
    {
        return await _repositoryWrapper.Roles.UpdateRole(role);
    }

    public async Task<bool> DeleteRole(int roleId)
    {
        return await _repositoryWrapper.Roles.DeleteRole(roleId);
    }
}