using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRentEntityRepository
{
    public IQueryable<RentEntity> GetRentEntityList();
    public IQueryable<RentEntity> GetRentEntityById(int rentEntityId);
    public IQueryable<RentEntity> GetRentEntityByUserId(int userId);
    public IQueryable<RentEntity> GetRentEntityByRoomId(int roomId);
    public IQueryable<RentEntity> GetRentEntityByRoomIdAndUserId(int roomId, int userId);
    public Task<RentEntity> AddRentEntity(RentEntity rentEntity);
    public Task<RentEntity> UpdateRoomEntity(RentEntity rentEntity);
    public Task<bool> DeleteEntityByUserId(int userId);
    public Task<bool> DeleteEntityByRoomId(int roomId);

}