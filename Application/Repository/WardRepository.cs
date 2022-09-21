using Application.IRepository;
using Infrastructure;

namespace Application.Repository;

public class WardRepository : IWardRepository
{
    private readonly ApplicationContext context;

    public WardRepository(ApplicationContext context)
    {
        this.context = context;
    }
}