using Application.IRepository;
using Infrastructure;

namespace Application.Repository;

public class DistrictRepository : IDistrictRepository
{
    private readonly ApplicationContext context;

    public DistrictRepository(ApplicationContext context)
    {
        this.context = context;
    }
}