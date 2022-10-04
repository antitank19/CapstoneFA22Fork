using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class AreaRepository : IAreaRepository
    {
    private readonly ApplicationContext context;

        public AreaRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}