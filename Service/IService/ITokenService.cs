using Domain.EntitiesForManagement;

namespace Service.IService;

public interface ITokenService
{
    string CreateToken(User user);
}