using Domain.EntitiesForManagement;

namespace Service.IService;

public interface ITokenService
{
    string CreateToken(Renter user);
}