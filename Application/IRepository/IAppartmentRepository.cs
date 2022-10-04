using Domain.EntitiesForManagement;

namespace Application.IRepository;

public interface IAppartmentRepository
{
    public IQueryable<Appartment> GetAppartmentList();
    public IQueryable<Appartment> GetAppartmentListByName(string name);
    public IQueryable<Appartment> GetAppartmentByAppartment(Appartment appartment);
    public IQueryable<Appartment> GetAppartmentDetail(int buildingId);
    public Task<bool> AddAppartment(Appartment building);
    public Task<bool> UpdateAppartment(Appartment building);
    public Task<bool> DeleteAppartment(int id);
}