using Application.IRepository;
using Infrastructure;

namespace Application.Repository;

public class CityRepository : ICityRepository
{
    private readonly ApplicationContext context;

    public CityRepository(ApplicationContext context)
    {
        this.context = context;
    }
}