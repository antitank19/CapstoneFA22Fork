using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class RoomRepository : IRoomRepository
{
    public IQueryable<Room> GetRoomList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Room> GetRoomDetail(int roomId)
    {
        throw new NotImplementedException();
    }

    public Task<Room> AddRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<Room> UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRoom(int roomId)
    {
        throw new NotImplementedException();
    }
}