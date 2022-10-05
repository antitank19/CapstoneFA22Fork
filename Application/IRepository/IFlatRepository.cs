using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IFlatRepository
{
    public IQueryable<Flat> GetFlatList();
    public IQueryable<Flat> GetFlatDetail(int flatId);
    public Task<Flat> AddFlat(Flat flat);
    public Task<Flat?> UpdateFlat(Flat flat);
    public Task<bool> DeleteFlat(int flatId);
}