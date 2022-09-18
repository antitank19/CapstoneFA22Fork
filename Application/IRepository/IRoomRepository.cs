using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRoomRepository
{
    public IQueryable<Room> GetRoomList();
    public IQueryable<Room> GetRoomDetail(int roomId);
    public Task<Room> AddRoom(Room room);
    public Task<Room> UpdateRoom(Room room);
    public Task<bool> DeleteRoom(int roomId);
}