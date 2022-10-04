using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class ExpenseHistoryRepository : IExpenseHistoryRepository
    {
    private readonly ApplicationContext context;

        public ExpenseHistoryRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}