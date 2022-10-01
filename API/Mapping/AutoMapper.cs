using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Basic DTOs
        CreateMap<Building, BuildingDto>()
            .ReverseMap();
        CreateMap<ContractHistory, ContractHistoryDto>()
            .ReverseMap();
        CreateMap<Contract, ContractDto>()
            .ReverseMap();
        CreateMap<Payment, PaymentDto>()
            .ReverseMap();
        CreateMap<PaymentType, PaymentTypeDto>()
            .ReverseMap();
        CreateMap<Role, RoleDto>()
            .ReverseMap();
        CreateMap<Flat, RoomDto>()
            .ReverseMap();
        CreateMap<FlatType, FlatTypeDto>()
            .ReverseMap();
        CreateMap<Bill, BillDto>()
            .ReverseMap();
        CreateMap<University, UniversityDto>()
            .ReverseMap();
        CreateMap<Renter, UserDto>()
            .ReverseMap()
            // For Odata Explicit Expansion
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Appartment, WardDto>()
            .ReverseMap();
    }
}