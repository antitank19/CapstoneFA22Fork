using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IAreaService
{
    public IQueryable<Area> GetAreaList();
    public Task<Area?> GetAreaById(int areaId);
    public Task<Area?> AddArea(Area area);
    public Task<Area?> UpdateArea(Area area);
    public Task<bool> ToggleAreaStatus(int areaId);
    public Task<bool> DeleteArea(int areaId);
}