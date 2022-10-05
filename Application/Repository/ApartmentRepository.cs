using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class ApartmentRepository : IApartmentRepository
{
    private readonly ApplicationContext _context;

    public ApartmentRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     AddExpenseHistory apartment to database
    /// </summary>
    /// <param name="apartment"></param>
    /// <returns></returns>
    public async Task<Apartment> AddApartment(Apartment apartment)
    {
        await _context.Appartments.AddAsync(apartment);
        await _context.SaveChangesAsync();
        return apartment;
    }

    /// <summary>
    ///     DeleteExpenseHistory apartment from database using Id
    /// </summary>
    /// <param name="apartmentId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteApartment(int apartmentId)
    {
        var apartmentFound = await _context.Appartments
            .FindAsync(apartmentId.ToString());
        if (apartmentFound == null)
            return false;

        // TODO: Should do a check to delete all related entities
        _context.Appartments.Remove(apartmentFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public IQueryable<Apartment> GetApartmentByArea(Area area)
    {
        return _context.Appartments
            .Where(x => x.Area.AreaId == area.AreaId)
            .AsQueryable();
    }

    /// <summary>
    ///     Get apartment detail by Id
    /// </summary>
    /// <param name="apartmentId"></param>
    /// <returns></returns>
    public IQueryable<Apartment> GetApartmentDetail(int apartmentId)
    {
        return _context.Appartments
            .Where(e => e.ApartmentId == apartmentId);
    }

    /// <summary>
    ///     Get apartment list
    /// </summary>
    /// <returns></returns>
    public IQueryable<Apartment> GetApartmentList()
    {
        return _context.Appartments.AsQueryable();
    }

    /// <summary>
    ///     Get apartment list containing name query string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Apartment> GetApartmentListByName(string name)
    {
        return _context.Appartments
            .Where(x => x.Name.Contains(name));
    }

    public async Task<Apartment?> UpdateApartment(Apartment? apartment)
    {
        var apartmentData = await _context.Appartments
            .FirstOrDefaultAsync(x => x.ApartmentId == apartment!.ApartmentId);

        if (apartmentData == null)
            return null;

        apartmentData.Name = apartment?.Name ?? apartmentData.Name;
        // TODO : Area -> Apartment -> Building -> Flat
        // TODO : Check if there is a building in the same area

        await _context.SaveChangesAsync();

        return apartmentData;
    }
}