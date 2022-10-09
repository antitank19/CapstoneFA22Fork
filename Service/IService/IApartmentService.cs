using Domain.EntitiesForManagement;

namespace Service.IService;

public interface IApartmentService
{
    public Task<IQueryable<Apartment>> GetApartmentList();
    public Task<Apartment?> GetApartmentById(int apartmentId);
    public Task<Apartment?> AddApartment(Apartment apartment);
    public Task<Apartment?> UpdateApartment(Apartment apartment);
    public Task<bool> DeleteApartment(int apartmentId);
}