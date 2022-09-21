using Application.IRepository;
using Application.IService;

namespace Application.Service;

public class RoomService : IRoomService
{
    private readonly IRepositoryWrapper reposities;

    public RoomService(IRepositoryWrapper reposities)
    {
        this.reposities = reposities;
    }
}