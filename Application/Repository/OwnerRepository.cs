using Application.IRepository;
using Domain.EntitiesForManagement;

namespace Application.Repository;

public class OwnerRepository : IOwnerRepository
{
    public IQueryable<Owner> GetOwnerList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Owner> GetOwnerContainingName(string name)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Owner> GetOwnerDetail(int ownerId)
    {
        throw new NotImplementedException();
    }

    public Task<Owner> AddOwner(Owner user)
    {
        throw new NotImplementedException();
    }

    public Task<Owner> UpdateOwner(Owner user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteOwner(int ownerId)
    {
        throw new NotImplementedException();
    }
}