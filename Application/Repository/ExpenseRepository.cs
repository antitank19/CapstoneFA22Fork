using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class ExpenseRepository : IExpenseRepository
    {
    private readonly ApplicationContext context;

        public ExpenseRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}