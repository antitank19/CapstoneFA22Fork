using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IFlatTypeRepository
{
    public IQueryable<FlatType> GetFlatTypeList();
    public IQueryable<FlatType> GetFlatTypeDetail(int roomTypeId);
    public Task<FlatType> AddFlatType(FlatType roomType);
    public Task<FlatType> UpdateFlatType(FlatType roomType);
    public Task<bool> DeleteFlatType(int roomTypeId);
}