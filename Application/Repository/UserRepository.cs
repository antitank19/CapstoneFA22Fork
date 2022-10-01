using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;

namespace Application.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext context;

    public UserRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public IQueryable<Renter> GetRenterList()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Renter> GetRenterListByRole(int roleId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Renter> GetRenterContainingName(string name)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Renter> GetRenterDetail(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<Renter> AddRenter(Renter user)
    {
        throw new NotImplementedException();
    }

    public Task<Renter> UpdateRenter(Renter user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRenter(int userId)
    {
        throw new NotImplementedException();
    }
}