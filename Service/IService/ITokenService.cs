using Domain.EntitiesForManagement;

namespace Service.IService;

public interface ITokenService
{
    string CreateTokenForRenter(Renter user);
    string CreateTokenForAccount(Account user);
}