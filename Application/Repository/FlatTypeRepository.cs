using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class FlatTypeRepository : IFlatTypeRepository
{
    private readonly ApplicationContext _context;

    public FlatTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all flat types
    /// </summary>
    /// <returns></returns>
    public IQueryable<FlatType> GetFlatTypeList()
    {
        return _context.FlatTypes.AsQueryable();
    }

    /// <summary>
    ///     Get flat type by id
    /// </summary>
    /// <param name="flatTypeId"></param>
    /// <returns></returns>
    public IQueryable<FlatType> GetFlatTypeDetail(int flatTypeId)
    {
        return _context.FlatTypes
            .Where(x => x.FlatTypeId == flatTypeId);
    }

    /// <summary>
    ///     AddInvoiceHistory new flat type
    /// </summary>
    /// <param name="flatType"></param>
    /// <returns></returns>
    public async Task<FlatType> AddFlatType(FlatType flatType)
    {
        await _context.FlatTypes.AddAsync(flatType);
        await _context.SaveChangesAsync();
        return flatType;
    }

    /// <summary>
    ///     Update flat type
    /// </summary>
    /// <param name="flatType"></param>
    /// <returns></returns>
    public async Task<FlatType?> UpdateFlatType(FlatType? flatType)
    {
        var flatTypeData = await _context.FlatTypes
            .FirstOrDefaultAsync(x => x.FlatTypeId == flatType!.FlatTypeId);
        if (flatTypeData == null)
            return null;

        flatTypeData.Capacity = flatType?.Capacity ?? flatTypeData.Capacity;
        flatTypeData.Status = flatType?.Status ?? flatTypeData.Status;

        await _context.SaveChangesAsync();
        return flatTypeData;
    }

    /// <summary>
    ///     Delete flat type
    /// </summary>
    /// <param name="flatTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteFlatType(int flatTypeId)
    {
        var flatTypeFound = await _context.FlatTypes
            .FindAsync(flatTypeId.ToString());
        if (flatTypeFound == null)
            return false;
        _context.FlatTypes.Remove(flatTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }
}