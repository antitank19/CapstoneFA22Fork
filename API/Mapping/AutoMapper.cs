using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // TODO : Remapping all DTOs and Entities
        // Basic DTOs
        MapAccount();
        MapBuilding();
        CreateMap<ContractHistory, ContractHistoryGetDto>()
            .ReverseMap();
        CreateMap<Contract, ContractGetDto>()
            .ReverseMap();
        CreateMap<Payment, PaymentGetDto>()
            .ReverseMap();
        CreateMap<PaymentType, PaymentTypeGetDto>()
            .ReverseMap();
        CreateMap<Role, RoleGetDto>()
            .ReverseMap();
        CreateMap<Flat, FlatGetDto>()
            .ReverseMap();
        CreateMap<FlatType, FlatTypeGetDto>()
            .ReverseMap();
        CreateMap<Bill, BillGetDto>()
            .ReverseMap();
        CreateMap<University, UniversityGetDto>()
            .ReverseMap();
        CreateMap<Renter, RenterGetDto>()
            .ReverseMap()
            // For Odata Explicit Expansion
            .ForAllMembers(o => o.ExplicitExpansion());
        /*
        CreateMap<Apartment, WardDto>()
            .ReverseMap();
        */
    }

    private void MapAccount()
    {
        CreateMap<Account, AccountGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AccountCreateDto, Account>()
            .ReverseMap();
        CreateMap<AccountUpdateDto, Account>()
            .ReverseMap();
    }

    private void MapBuilding()
    {
        CreateMap<Building, BuildingGetDto>()
                    .ReverseMap();
    }
}