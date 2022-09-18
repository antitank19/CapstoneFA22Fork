using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IOwnerRepository
{
    public IQueryable<Owner> GetOwnerList();
    public IQueryable<Owner> GetOwnerContainingName(string name);
    public IQueryable<Owner> GetOwnerDetail(int ownerId);
    public Task<Owner> AddOwner(Owner user);
    public Task<Owner> UpdateOwner(Owner user);
    public Task<bool> DeleteOwner(int ownerId);
}