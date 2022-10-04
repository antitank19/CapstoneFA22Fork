using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class FeedbackTypeRepository : IFeedbackTypeRepository
    {
    private readonly ApplicationContext context;

        public FeedbackTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}