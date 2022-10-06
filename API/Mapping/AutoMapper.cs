using AutoMapper;
using Domain.EntitiesDTO;
using Domain.EntitiesDTO.Account;
using Domain.EntitiesDTO.Renter;
using Domain.EntitiesDTO.Role;
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
        MapRenter();
        /*
        CreateMap<Apartment, WardDto>()
            .ReverseMap();
        */
    }

    private void MapRenter()
    {
        CreateMap<Renter, RenterGetDto>()
                    .ReverseMap()
                    .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterCreateDto, Renter>()
            .ReverseMap();
        CreateMap<RenterUpdateDto, Renter>().ReverseMap()
                .ReverseMap();
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