using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRoleService
{
    public IQueryable<Role> GetRoleList();
    public Task<Role?> GetRoleById(int roleId);
    public Task<Role?> AddRole(Role role);
    public Task<Role?> UpdateRole(Role role);
    public Task<bool> DeleteRole(int roleId);
}