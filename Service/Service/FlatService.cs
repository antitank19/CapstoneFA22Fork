using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class FlatService : IFlatService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Flat> GetFlatList()
    {
        return _repositoryWrapper.Flats.GetFlatList();
    }

    public async Task<Flat?> GetFlatById(int flatId)
    {
        return await _repositoryWrapper.Flats.GetFlatDetail(flatId)
            .FirstOrDefaultAsync();
    }

    public async Task<Flat?> AddFlat(Flat flat)
    {
        return await _repositoryWrapper.Flats.AddFlat(flat);
    }

    public async Task<Flat?> UpdateFlat(Flat flat)
    {
        return await _repositoryWrapper.Flats.UpdateFlat(flat);
    }

    public async Task<bool> DeleteFlat(int flatId)
    {
        return await _repositoryWrapper.Flats.DeleteFlat(flatId);
    }
}