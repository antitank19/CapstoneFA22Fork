using Application.IRepository;
using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service;

public class ApartmentService : IApartmentService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ApartmentService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public IQueryable<Apartment> GetApartmentList()
    {
        return _repositoryWrapper.Apartments.GetApartmentList()
            .AsQueryable();
    }

    public async Task<Apartment?> GetApartmentById(int apartmentId)
    {
        return await _repositoryWrapper.Apartments.GetApartmentDetail(apartmentId)
            .FirstOrDefaultAsync();
    }

    public async Task<Apartment?> AddApartment(Apartment apartment)
    {
        return await _repositoryWrapper.Apartments.AddApartment(apartment);
    }

    public async Task<Apartment?> UpdateApartment(Apartment apartment)
    {
        return await _repositoryWrapper.Apartments.UpdateApartment(apartment);
    }

    public async Task<bool> DeleteApartment(int apartmentId)
    {
        return await _repositoryWrapper.Apartments.DeleteApartment(apartmentId);
    }
}