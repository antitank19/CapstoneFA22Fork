using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly IReposityWrapper reposities;

    public RoomTypeService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}