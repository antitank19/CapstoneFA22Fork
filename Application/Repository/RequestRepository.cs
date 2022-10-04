using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class RequestRepository : IRequestRepository
    {
        private ApplicationContext context;

        public RequestRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}