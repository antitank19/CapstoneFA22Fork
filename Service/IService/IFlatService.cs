using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IFlatService
{
    public IQueryable<Flat> GetFlatList();
    public Task<Flat?> GetFlatById(int flatId);
    public Task<Flat?> AddFlat(Flat flat);
    public Task<Flat?> UpdateFlat(Flat flat);
    public Task<bool> DeleteFlat(int flatId);
}