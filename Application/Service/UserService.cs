using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IRepositoryWrapper reposities;

    public UserService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}