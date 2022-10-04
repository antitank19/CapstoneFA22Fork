using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class ServiceRepository : IServiceRepository
    {
        private ApplicationContext context;

        public ServiceRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}