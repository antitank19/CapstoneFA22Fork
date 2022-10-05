using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IApartmentRepository
{
    public IQueryable<Apartment> GetApartmentList();
    public IQueryable<Apartment> GetApartmentListByName(string name);
    public IQueryable<Apartment> GetApartmentByArea(Area area);
    public IQueryable<Apartment> GetApartmentDetail(int apartmentId);
    public Task<Apartment> AddApartment(Apartment apartment);
    public Task<Apartment?> UpdateApartment(Apartment apartment);
    public Task<bool> DeleteApartment(int id);
}