using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Basic DTOs
        CreateMap<Building, BuildingDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<ContractHistory, ContractHistoryDto>().ReverseMap();
        CreateMap<Contract, ContractDto>().ReverseMap();
        CreateMap<District, DistrictDto>().ReverseMap();
        CreateMap<Owner, OwnerDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
        CreateMap<RentEntity, RentEntityDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<University, UniversityDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Ward, WardDto>().ReverseMap();
    }
}