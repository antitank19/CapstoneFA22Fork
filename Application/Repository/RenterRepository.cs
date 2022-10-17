using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RenterRepository : IRenterRepository
{
    private readonly ApplicationContext _context;

    public RenterRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get a list of all renters
    /// </summary>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterList()
    {
        return _context.Renters.AsQueryable();
    }

    /// <summary>
    ///     Get a list of all renters by renter name query
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterContainingName(string name)
    {
        return _context.Renters
            .Where(x => x.FullName.Contains(name));
    }

    /// <summary>
    ///     Get a renter detail by Id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterDetail(int userId)
    {
        return _context.Renters
            .Where(x => x.RenterId == userId);
    }

    /// <summary>
    ///     Create a new renter
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<Renter> AddRenter(Renter user)
    {
        await _context.Renters.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    /// <summary>
    ///     UpdateExpenseHistory a renter
    /// </summary>
    /// <param name="renter"></param>
    /// <returns></returns>
    public async Task<Renter?> UpdateRenter(Renter? renter)
    {
        var userData = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renter!.RenterId);

        if (userData == null)
            return null;

        userData.FullName = renter?.FullName ?? userData.FullName;
        userData.Email = renter?.Email ?? userData.Email;
        userData.Password = renter?.Password ?? userData.Password;
        userData.Phone = renter?.Phone ?? userData.Phone;
        userData.Major = renter?.Major ?? userData.Major;
        userData.Image = renter?.Image ?? userData.Image;
        userData.Address = renter?.Address ?? userData.Address;
        userData.University = renter?.University ?? userData.University;
        userData.Gender = renter?.Gender ?? userData.Gender;
        userData.BirthDate = renter?.BirthDate ?? userData.BirthDate;

        await _context.SaveChangesAsync();

        return renter;
    }

    /// <summary>
    ///     Disable renter
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);
        if (renterFound == null)
            return false;
        _ = renterFound.Status == !renterFound.Status;
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Remove renter by Id
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (renterFound == null)
            return false;

        _context.Renters.Remove(renterFound);
        await _context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    ///     Get renter based on username and passowrd
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Renter?> GetRenter(string username, string password)
    {
        return _context.Renters
            .Where(a => a.Username == username && a.Password == password);
    }
}