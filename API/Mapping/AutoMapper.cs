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
        MapApartment();
        MapArea();
        MapBill();
        MapBuilding();
        MapContract();
        MapContractHistory();
        MapExpense();
        MapExpenseType();
        MapExpenseHistory();
        MapFeedback();
        MapFeedbackType();
        MapFlat();
        MapFlatType();
        MapInvoice();
        MapInvoiceHistory();
        MapMajor();
        MapOrder();
        MapOrderDetail();
        MapPayment();
        MapPaymentType();
        MapRenter();
        MapRequest();
        MapRequestType();
        MapRole();
        MapService();
        MapServiceType();
        MapUniversity();
    }

    private void MapExpenseHistory()
    {
        CreateMap<ExpenseHistory, ExpenseHistoryGetDto>()
                    .ReverseMap()
                    .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapUniversity()
    {
        CreateMap<University, UniversityGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapServiceType()
    {
        CreateMap<ServiceType, ServiceTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapService()
    {
        CreateMap<ServiceEntity, ServiceGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapRole()
    {
        CreateMap<Role, RoleGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapRequestType()
    {
        CreateMap<RequestType, RequestTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapRequest()
    {
        CreateMap<Request, RequestGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapPaymentType()
    {
        CreateMap<PaymentType, PaymentTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapPayment()
    {
        CreateMap<Payment, PaymentGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapOrderDetail()
    {
        CreateMap<OrderDetail, OrderDetailGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapOrder()
    {
        CreateMap<Order, OrderGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapMajor()
    {
        CreateMap<Major, MajorGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapInvoiceHistory()
    {
        CreateMap<InvoiceHistory, InvoiceHistoryGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapInvoice()
    {
        CreateMap<Invoice, InvoiceGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapFlatType()
    {
        CreateMap<FlatType, FlatTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapFlat()
    {
        CreateMap<Flat, FlatGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapFeedbackType()
    {
        CreateMap<FeedbackType, FeedbackTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapFeedback()
    {
        CreateMap<Feedback, FeedbackGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapExpenseType()
    {
        CreateMap<ExpenseType, ExpenseTypeGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapExpense()
    {
        CreateMap<Expense, ExpenseGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapContractHistory()
    {
        CreateMap<ContractHistory, ContractHistoryGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapContract()
    {
        CreateMap<Contract, ContractGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapBill()
    {
        CreateMap<Bill, BillGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapArea()
    {
        CreateMap<Area, AreaGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }

    private void MapApartment()
    {
        CreateMap<Apartment, ApartmentGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
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
            //.ReverseMap()
            //.ForMember(e=>e.Role, o=>o.ExplicitExpansion())
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AccountCreateDto, Account>()
            .ReverseMap();
        CreateMap<AccountUpdateDto, Account>()
            .ReverseMap();
    }

    private void MapBuilding()
    {
        CreateMap<Building, BuildingGetDto>()
            .ReverseMap()
            .ForAllMembers(o => o.ExplicitExpansion());
    }
}