using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class MajorRepository : IMajorRepository
    {
        private ApplicationContext context;

        public MajorRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}