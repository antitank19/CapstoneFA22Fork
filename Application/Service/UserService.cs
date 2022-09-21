using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IReposityWrapper reposities;

    public UserService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}