using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class InvoiceRepository : IInvoiceRepository
    {
    private readonly ApplicationContext context;

        public InvoiceRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}