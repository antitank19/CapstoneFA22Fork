using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class FlatRepository : IFlatRepository
{
    private readonly ApplicationContext context;

    public FlatRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Flat> GetFlatList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Flat> GetFlatDetail(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<Flat> AddFlat(Flat room)
    {
        throw new NotImplementedException();
    }

    public Task<Flat> UpdateFlat(Flat room)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFlat(int roomId)
    {
        throw new NotImplementedException();
    }
}