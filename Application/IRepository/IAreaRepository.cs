using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IAreaRepository
{
    public IQueryable<Area> GetAreaList();
    public IQueryable<Area> GetAreaDetail(int areaId);
    public Task<Area> AddArea(Area area);
    public Task<Area?> UpdateArea(Area? area);
    public Task<bool> ToggleArea(int areaId);
    public Task<bool> DeleteArea(int areaId);
}