using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRoleRepository
{
    public IQueryable<Role> GetRoleList();
    public Task<Role> GetRoleDetail(int roleId);
    public Task<Role> AddRole(Role role);
    public Task<Role?> UpdateRole(Role role);
    public Task<bool> DeleteRole(int roleId);
}