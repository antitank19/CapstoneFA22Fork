using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class RequestTypeRepository : IRequestTypeRepository
    {
        private ApplicationContext context;

        public RequestTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}