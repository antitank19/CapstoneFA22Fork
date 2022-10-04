using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class OrderDetailRepository : IOrderDetailRepository
    {
        private ApplicationContext context;

        public OrderDetailRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}