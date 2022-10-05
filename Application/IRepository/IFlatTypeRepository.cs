using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IFlatTypeRepository
{
    public IQueryable<FlatType> GetFlatTypeList();
    public IQueryable<FlatType> GetFlatTypeDetail(int flatTypeId);
    public Task<FlatType> AddFlatType(FlatType flatTypeId);
    public Task<FlatType?> UpdateFlatType(FlatType flatTypeId);
    public Task<bool> DeleteFlatType(int flatTypeId);
}