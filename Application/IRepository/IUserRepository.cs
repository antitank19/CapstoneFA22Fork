using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IUserRepository
{
    public IQueryable<User> GetUserList();
    public IQueryable<User> GetUserListByRole(int roleId);
    public IQueryable<User> GetUserContainingName(string name);
    public IQueryable<User> GetUserDetail(int userId);
    public Task<User> AddUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<bool> DeleteUser(int userId);
}