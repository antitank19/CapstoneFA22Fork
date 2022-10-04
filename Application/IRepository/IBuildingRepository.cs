using Domain.EntitiesForManagement;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IBuildingRepository
    {
        public IQueryable<Building> GetList();
        public IQueryable<Building> GetDetail(int Id);
        public Task<Building> Add(Building entity);
        public Task<Building> Update(Building entity);
        public Task<bool> Delete(int id);
    }
}