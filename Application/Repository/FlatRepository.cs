using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class FlatRepository : IFlatRepository
{
    private readonly ApplicationContext _context;

    public FlatRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all flats
    /// </summary>
    /// <returns></returns>
    public IQueryable<Flat> GetFlatList()
    {
        return _context.Flats.AsQueryable();
    }

    /// <summary>
    ///     Get flat by id
    /// </summary>
    /// <param name="flatId"></param>
    /// <returns></returns>
    public IQueryable<Flat> GetFlatDetail(int flatId)
    {
        return _context.Flats
            .Where(x => x.FlatId == flatId);
    }

    /// <summary>
    ///     AddInvoiceHistory new flat
    /// </summary>
    /// <param name="flat"></param>
    /// <returns></returns>
    public async Task<Flat> AddFlat(Flat flat)
    {
        await _context.Flats.AddAsync(flat);
        await _context.SaveChangesAsync();
        return flat;
    }

    /// <summary>
    ///     Update Flat details
    /// </summary>
    /// <param name="flat"></param>
    /// <returns></returns>
    public async Task<Flat?> UpdateFlat(Flat? flat)
    {
        var flatData = await _context.Flats
            .FirstOrDefaultAsync(x => x.FlatId == flat!.FlatId);
        if (flatData == null)
            return null;

        flatData.Name = flat?.Name ?? flatData.Name;
        flatData.Description = flat?.Description ?? flatData.Description;
        flatData.Status = flat?.Status ?? flatData.Status;

        await _context.SaveChangesAsync();
        return flatData;
    }

    /// <summary>
    ///     Delete Flat
    /// </summary>
    /// <param name="flatId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteFlat(int flatId)
    {
        var flatFound = await _context.Flats
            .FindAsync(flatId.ToString());
        if (flatFound == null)
            return false;
        _context.Flats.Remove(flatFound);
        await _context.SaveChangesAsync();
        return true;
    }
}