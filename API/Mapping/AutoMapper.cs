using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesDTO.ContractHistory;
using Domain.EntitiesForManagement;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Basic DTOs
        CreateMap<Building, BuildingGetDto>()
            .ReverseMap();
        CreateMap<ContractHistory, ContractHistoryGetDto>()
            .ReverseMap();
        CreateMap<Contract, ContractGetDto>()
            .ReverseMap();
        CreateMap<Payment, PaymentDto>()
            .ReverseMap();
        CreateMap<PaymentType, PaymentTypeDto>()
            .ReverseMap();
        CreateMap<Role, RoleGetDto>()
            .ReverseMap();
        CreateMap<Flat, RoomDto>()
            .ReverseMap();
        CreateMap<FlatType, FlatTypeGetDto>()
            .ReverseMap();
        CreateMap<Bill, BillGetDto>()
            .ReverseMap();
        CreateMap<University, UniversityGetDto>()
            .ReverseMap();
        CreateMap<Renter, UserDto>()
            .ReverseMap()
            // For Odata Explicit Expansion
            .ForAllMembers(o => o.ExplicitExpansion());
        /*
        CreateMap<Appartment, WardDto>()
            .ReverseMap();
        */
        
    }
}