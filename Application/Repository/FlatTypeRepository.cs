using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class FlatTypeRepository : IFlatTypeRepository
{
    private readonly ApplicationContext context;

    public FlatTypeRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<FlatType> GetFlatTypeList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<FlatType> GetFlatTypeDetail(int flatType)
    {
        throw new NotImplementedException();
    }

    public Task<FlatType> AddFlatType(FlatType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<FlatType> UpdateFlatType(FlatType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFlatType(int flatType)
    {
        throw new NotImplementedException();
    }
}