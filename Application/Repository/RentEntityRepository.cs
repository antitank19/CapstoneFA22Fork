using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class RentEntityRepository : IRentEntityRepository
{
    public IQueryable<RentEntity> GetRentEntityList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentEntity> GetRentEntityById(int rentEntityId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentEntity> GetRentEntityByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentEntity> GetRentEntityByRoomId(int roomId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<RentEntity> GetRentEntityByRoomIdAndUserId(int roomId, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<RentEntity> AddRentEntity(RentEntity rentEntity)
    {
        throw new NotImplementedException();
    }

    public Task<RentEntity> UpdateRoomEntity(RentEntity rentEntity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEntityByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEntityByRoomId(int roomId)
    {
        throw new NotImplementedException();
    }
}