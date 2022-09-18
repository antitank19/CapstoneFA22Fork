using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRoomTypeRepository
{
    public IQueryable<RoomType> GetRoomTypeList();
    public IQueryable<RoomType> GetRoomTypeDetail(int roomTypeId);
    public Task<RoomType> AddRoomType(RoomType roomType);
    public Task<RoomType> UpdateRoomType(RoomType roomType);
    public Task<bool> DeleteRoomType(int roomTypeId);
}