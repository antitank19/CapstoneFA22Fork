using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class ServiceTypeRepository : IServiceTypeRepository
    {
        private ApplicationContext context;

        public ServiceTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}