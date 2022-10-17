using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IRenterService
{
    public IQueryable<Renter> GetRenterList();
    public Task<Renter?> GetRenterById(int renterId);
    public Task<Renter?> AddRenter(Renter renter);
    public Task<Renter?> UpdateRenter(Renter renter);
    public Task<bool> ToggleRenterStatus(int renterId);
    public Task<bool> DeleteRenter(int renterId);
    public Task<Renter> Login(string username, string password);
    public Task<Renter?> RenterLogin(string username, string password);
}