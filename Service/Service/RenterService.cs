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

    public async Task<IEnumerable<Renter?>> GetRenterList()
    {
        return await _repositoryWrapper.Renters.GetRenterList()
            .ToListAsync();
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
}