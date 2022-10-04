using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationContext context;

    public RoleRepository(ApplicationContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Get all roles
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Role> GetRoleList()
    {
        return context.Roles;
    }

    /// <summary>
    /// Get role details by id
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Role> GetRoleDetail(int roleId)
    {
        return context.Roles
            .Where(x => x.RoleId == roleId);
    }

    /// <summary>
    /// Add new role
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<Role> AddRole(Role role)
    {
        await context.Roles.AddAsync(role);
        await context.SaveChangesAsync();
        return role;
    }

    /// <summary>
    /// Update role details
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public async Task<Role?> UpdateRole(Role role)
    {
        try
        {
            var roleData = await context.Roles
                .FirstOrDefaultAsync(x => x.RoleId == role.RoleId);
            if (roleData == null)
                return null;
            roleData.RoleName ??= role.RoleName;
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        return role;
    }

    /// <summary>
    /// Disable Role
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> DeleteRole(int roleId)
    {
        var roleFound = await context.Roles
            .FirstOrDefaultAsync(x => x.RoleId == roleId);
        if (roleFound == null)
            return false;
        _ = roleFound.Status == !roleFound.Status;
        await context.SaveChangesAsync();
        return true;
    }
}