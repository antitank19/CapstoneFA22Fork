using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoomService : IRoomService
{
    private readonly IReposityWrapper reposities;

    public RoomService(IReposityWrapper reposities)
    {
        this.reposities = reposities;
    }
}