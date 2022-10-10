using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class FlatTypeService : IFlatTypeService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatTypeService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<FlatType> GetFlatTypeList()
    {
        return _repositoryWrapper.FlatTypes.GetFlatTypeList();
    }

    public async Task<FlatType?> GetFlatTypeById(int flatTypeId)
    {
        return await _repositoryWrapper.FlatTypes.GetFlatTypeDetail(flatTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<FlatType?> AddFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.AddFlatType(flatType);
    }

    public async Task<FlatType?> UpdateFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.UpdateFlatType(flatType);
    }

    public async Task<bool> DeleteFlatType(int flatTypeId)
    {
        return await _repositoryWrapper.FlatTypes.DeleteFlatType(flatTypeId);
    }
}