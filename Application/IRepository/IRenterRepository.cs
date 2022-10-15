using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IRenterRepository
{
    public IQueryable<Renter> GetRenterList();
    public IQueryable<Renter> GetRenterContainingName(string name);
    public IQueryable<Renter> GetRenterDetail(int renterId);
    public Task<Renter> AddRenter(Renter renter);
    public Task<Renter?> UpdateRenter(Renter renter);
    public Task<bool> ToggleRenter(int renterId);
    public Task<bool> DeleteRenter(int renterId);
    public IQueryable<Renter?> GetRenter(string username, string password);

}