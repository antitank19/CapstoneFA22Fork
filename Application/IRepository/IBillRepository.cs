using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IBillRepository
{
    public IQueryable<Area> GetList();
    public IQueryable<Area> GetDetail(int Id);
    public Task<Area> Add(Area entity);
    public Task<Area> Update(Area entity);
    public Task<bool> Delete(int id);
}