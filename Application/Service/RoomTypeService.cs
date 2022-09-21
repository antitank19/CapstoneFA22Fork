using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRepositoryWrapper reposities;

    public RoomTypeService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}