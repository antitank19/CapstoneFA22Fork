using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IFlatTypeService
{
    public Task<IEnumerable<FlatType?>> GetFlatTypeList();
    public Task<FlatType?> GetFlatTypeById(int flatTypeId);
    public Task<FlatType?> AddFlatType(FlatType flatType);
    public Task<FlatType?> UpdateFlatType(FlatType flatType);
    public Task<bool> DeleteFlatType(int flatTypeId);
}