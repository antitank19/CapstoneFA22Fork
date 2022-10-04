using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class InvoiceHistoryRepository : IInvoiceHistoryRepository
    {
        private ApplicationContext context;

        public InvoiceHistoryRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}