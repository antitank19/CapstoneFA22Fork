using System.Diagnostics.CodeAnalysis;
using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RenterRepository : IRenterRepository
{
    private readonly ApplicationContext context;

    public RenterRepository(ApplicationContext context)
    {
        this.context = context;
    }

    /// <summary>
    /// Get a list of all renters
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Renter> GetRenterList()
    {
        return context.Renters;
    }

    /// <summary>
    /// Get renter detail by role Id
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Renter> GetRenterListByRole(int roleId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a list of all renters by renter name query
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Renter> GetRenterContainingName(string name)
    {
        return context.Renters.Where(a => string.Equals(a.FullName, name,
            StringComparison.CurrentCultureIgnoreCase));
    }

    /// <summary>
    /// Get a renter detail by Id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<Renter> GetRenterDetail(int userId)
    {
        return context.Renters
            .Where(x => x.RenterId == userId);
    }

    /// <summary>
    /// Create a new renter
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Renter> AddRenter(Renter user)
    {
        await context.Renters.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    /// <summary>
    /// Update a renter
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Renter?> UpdateRenter(Renter? user)
    {
        try
        {
            var userData = await context.Renters
                .FirstOrDefaultAsync(x => x.RenterId == user!.RenterId);
            if (userData == null)
                return null;
            userData.FullName = user?.FullName ?? userData.FullName;
            userData.Email = user?.Email ?? userData.Email;
            userData.Password = user?.Password ?? userData.Password;
            userData.Phone = user?.Phone ?? userData.Phone;
            userData.Major = user?.Major ?? userData.Major;
            userData.Image = user?.Image ?? userData.Image;
            userData.Address = user?.Address ?? userData.Address;
            userData.University = user?.University ?? userData.University;
            userData.Gender = user?.Gender ?? userData.Gender;
            userData.BirthDate = user?.BirthDate ?? userData.BirthDate;

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return user;    
    }

    /// <summary>
    /// Disable renter
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRenter(int userId)
    {
        var renterFound = await context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == userId);
        if (renterFound == null)
            return false;
        _ = renterFound.Status == !renterFound.Status;
        await context.SaveChangesAsync();
        return true;
    }
}