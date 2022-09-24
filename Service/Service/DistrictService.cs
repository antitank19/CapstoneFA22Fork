using Application.IRepository;
using Service.IService;

namespace Service.Service;

public class DistrictService : IDistrictService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DistrictService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
}