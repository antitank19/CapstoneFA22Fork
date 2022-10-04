using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class ExpenseTypeRepository : IExpenseTypeRepository
    {
    private readonly ApplicationContext context;

        public ExpenseTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}