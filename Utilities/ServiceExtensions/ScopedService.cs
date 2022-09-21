using Application.IRepository;
using Application.IService;
using Application.Repository;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Utilities.ServiceExtensions;

public static class ScopedService
{
    public static IServiceCollection AddScopedService(this IServiceCollection services)
    {
        /*
        services.AddScoped<IBuildingService, BuildingService>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();

        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICityRepository, CityRepository>();

        services.AddScoped<IContractHistoryService, ContractHistoryService>();
        services.AddScoped<IContractHistoryRepository, ContractHistoryRepository>();

        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<IContractRepository, ContractRepository>();

        services.AddScoped<IDistrictService, DistrictService>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();

        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();

        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        
        services.AddScoped<IPaymentTypeService, PaymentTypeService>();
        services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

        services.AddScoped<IRentEntityService, RentEntityService>();
        services.AddScoped<IRentEntityRepository, RentEntityRepository>();

        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        
        services.AddScoped<IUniversityService, UniversityService>();
        services.AddScoped<IUniversityRepository, UniversityRepository>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IWardService, WardService>();
        services.AddScoped<IWardRepository, WardRepository>();
        */
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IReposityWrapper, RepositoryWrapper>();

        return services;

    }
}