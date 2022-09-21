using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly ApplicationContext context;

    public RoomTypeRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<RoomType> GetRoomTypeList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<RoomType> GetRoomTypeDetail(int roomTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<RoomType> AddRoomType(RoomType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<RoomType> UpdateRoomType(RoomType roomType)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRoomType(int roomTypeId)
    {
        throw new NotImplementedException();
    }
}