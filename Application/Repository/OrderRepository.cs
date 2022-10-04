using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        private ApplicationContext context;

        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}