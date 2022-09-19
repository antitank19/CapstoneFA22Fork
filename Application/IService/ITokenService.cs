using Domain.EntitiesForManagement;

namespace Application.IService;

public interface ITokenService
{
    string CreateToken(User user);
}