using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    internal class AppartmentRepository : IAppartmentRepository
    {
        private readonly ApplicationContext context;

        public AppartmentRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAppartment(Appartment entity)
        {
            try
            {
                if (context.Appartments.Any(e => e.AppartmentId == entity.AppartmentId))
                {
                    throw new ArgumentException("Existed");
                }
                await context.Appartments.AddAsync(entity);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAppartment(int id)
        {
            try
            {
                var found = await context.Appartments.FirstOrDefaultAsync(e => e.AppartmentId == id);
                if (found==null)
                {
                    throw new ArgumentException("Not found");
                }
                context.Appartments.Remove(found);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<Appartment> GetAppartmentByAppartment(Appartment appartment)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appartment> GetAppartmentDetail(int buildingId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appartment> GetAppartmentList()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appartment> GetAppartmentListByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Appartment> UpdateAppartment(Appartment building)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAppartmentRepository.UpdateAppartment(Appartment building)
        {
            throw new NotImplementedException();
        }
    }
}