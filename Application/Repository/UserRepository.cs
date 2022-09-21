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

    public IQueryable<User> GetUserList()
    {
        throw new NotImplementedException();

    }

    public IQueryable<User> GetUserListByRole(int roleId)
    {
        throw new NotImplementedException();

    }

    public IQueryable<User> GetUserContainingName(string name)
    {
        throw new NotImplementedException();

    }

    public IQueryable<User> GetUserDetail(int userId)
    {
        throw new NotImplementedException();

    }

    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();

    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();

    }

    public Task<bool> DeleteUser(int userId)
    {
        throw new NotImplementedException();

    }
}