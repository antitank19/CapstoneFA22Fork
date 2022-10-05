using Application.IRepository;
using Domain.EntitiesForManagement;
using Service.IService;

namespace Service.Service;

public class FlatService : IFlatService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<Flat?>> GetFlatList()
    {
        throw new NotImplementedException();
    }

    public async Task<Flat?> GetFlatById(int flatId)
    {
        throw new NotImplementedException();
    }

    public async Task<Flat?> AddFlat(Flat flat)
    {
        throw new NotImplementedException();
    }

    public async Task<Flat?> UpdateFlat(Flat flat)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteFlat(int flatId)
    {
        throw new NotImplementedException();
    }
}