using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class RenterService : IRenterService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RenterService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Renter> GetRenterList()
    {
        return _repositoryWrapper.Renters.GetRenterList();
    }

    public async Task<Renter?> GetRenterById(int renterId)
    {
        return await _repositoryWrapper.Renters.GetRenterDetail(renterId)
            .FirstOrDefaultAsync();
    }

    public async Task<Renter?> AddRenter(Renter renter)
    {
        return await _repositoryWrapper.Renters.AddRenter(renter);
    }

    public async Task<Renter> Login(string username, string password)
    {
        var list = _repositoryWrapper.Renters.GetRenterList();
        var logined = await list.SingleOrDefaultAsync(e => e.Username == username && e.Password == password);
        return logined;
    }

    public async Task<Renter?> UpdateRenter(Renter renter)
    {
        return await _repositoryWrapper.Renters.UpdateRenter(renter);
    }

    public async Task<bool> ToggleRenterStatus(int renterId)
    {
        return await _repositoryWrapper.Renters.ToggleRenter(renterId);
    }

    public async Task<bool> DeleteRenter(int renterId)
    {
        return await _repositoryWrapper.Renters.DeleteRenter(renterId);
    }

    public async Task<Renter?> RenterLogin(string username, string password)
    {
        return await _repositoryWrapper.Renters.GetRenter(username, password)
            .FirstOrDefaultAsync();
    }
}