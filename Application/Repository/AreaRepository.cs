﻿using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class AreaRepository : IAreaRepository
{
    private readonly ApplicationContext _context;

    public AreaRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get list of areas
    /// </summary>
    /// <returns></returns>
    public IQueryable<Area> GetAreaList()
    {
        return _context.Areas.AsQueryable();
    }

    /// <summary>
    ///     Get area detail by id
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public IQueryable<Area> GetAreaDetail(int areaId)
    {
        return _context.Areas
            .Where(x => x.AreaId == areaId);
    }

    /// <summary>
    ///     AddExpenseHistory new area
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<Area> AddArea(Area area)
    {
        await _context.Areas.AddAsync(area);
        await _context.SaveChangesAsync();
        return area;
    }

    /// <summary>
    ///     UpdateExpenseHistory area detail
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public async Task<Area?> UpdateArea(Area? area)
    {
        var areaData = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == area!.AreaId);

        if (areaData == null)
            return null;

        areaData.Address = area?.Address ?? areaData.Address;
        areaData.Name = area?.Name ?? areaData.Name;
        areaData.Status = area?.Status ?? areaData.Status;

        await _context.SaveChangesAsync();

        return areaData;
    }

    /// <summary>
    ///     Toggle area status
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleArea(int areaId)
    {
        var areaFound = await _context.Areas
            .FirstOrDefaultAsync(x => x.AreaId == areaId);
        if (areaFound == null)
            return false;
        _ = areaFound.Status == !areaFound.Status;
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     DeleteFeedback area
    /// </summary>
    /// <param name="areaId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteArea(int areaId)
    {
        var areaFound = await _context.Areas
            .FindAsync(areaId.ToString());
        if (areaFound == null)
            return false;

        // TODO: Should do a check to delete all related entities
        _context.Areas.Remove(areaFound);
        await _context.SaveChangesAsync();
        return true;
    }
}