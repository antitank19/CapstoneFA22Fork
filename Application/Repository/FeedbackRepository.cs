using Application.IRepository;
using Infrastructure;

namespace Application.Repository
{
    internal class FeedbackRepository : IFeedbackRepository
    {
    private readonly ApplicationContext context;

        public FeedbackRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}