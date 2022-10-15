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
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ExpenseHistoryGetDto, ExpenseHistory>();
        CreateMap<ExpenseHistoryCreateDto, ExpenseHistory>()
            .ReverseMap();
        CreateMap<ExpenseHistoryUpdateDto, ExpenseHistory>()
            .ReverseMap();
    }

    private void MapUniversity()
    {
        CreateMap<University, UniversityGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<UniversityGetDto, University>();
        CreateMap<UniversityCreateDto, University>()
            .ReverseMap();
        CreateMap<UniversityUpdateDto, University>()
            .ReverseMap();
    }

    private void MapServiceType()
    {
        CreateMap<ServiceType, ServiceTypeGetDto>()
            .ForMember(
            o => o.Services,
            opt => opt.MapFrom(src => src.ServiceEntities)
            )
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceTypeGetDto, ServiceType>();
        CreateMap<ServiceTypeCreateDto, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeUpdateDto, ServiceType>()
            .ReverseMap();
    }

    private void MapService()
    {
        CreateMap<ServiceEntity, ServiceGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceGetDto, ServiceEntity>();
        CreateMap<ServiceCreateDto, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceUpdateDto, ServiceEntity>()
            .ReverseMap();
    }

    private void MapRole()
    {
        CreateMap<Role, RoleGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RoleGetDto, Role>();
        CreateMap<RoleCreateDto, Role>()
            .ReverseMap();
        CreateMap<RoleUpdateDto, Role>()
            .ReverseMap();
    }

    private void MapRequestType()
    {
        CreateMap<RequestType, RequestTypeGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RequestTypeGetDto, ExpenseType>();
        CreateMap<ExpenseTypeCreateDto, ExpenseType>()
            .ReverseMap();
        CreateMap<ExpenseTypeUpdateDto, ExpenseType>()
            .ReverseMap();
    }

    private void MapRequest()
    {
        CreateMap<Request, RequestGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ExpenseTypeGetDto, ExpenseType>();
        CreateMap<ExpenseTypeCreateDto, ExpenseType>()
            .ReverseMap();
        CreateMap<ExpenseTypeUpdateDto, ExpenseType>()
            .ReverseMap();
    }

    private void MapPaymentType()
    {
        CreateMap<PaymentType, PaymentTypeGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<PaymentTypeGetDto, PaymentType>();
        CreateMap<PaymentTypeCreateDto, PaymentType>()
            .ReverseMap();
        CreateMap<PaymentTypeUpdateDto, PaymentType>()
            .ReverseMap();
    }

    private void MapPayment()
    {
        CreateMap<Payment, PaymentGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ExpenseTypeGetDto, ExpenseType>();
        CreateMap<ExpenseTypeCreateDto, ExpenseType>()
            .ReverseMap();
        CreateMap<ExpenseTypeUpdateDto, ExpenseType>()
            .ReverseMap();
    }

    private void MapOrderDetail()
    {
        CreateMap<OrderDetail, OrderDetailGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<OrderDetailGetDto, OrderDetail>();
        CreateMap<OrderDetailCreateDto, OrderDetail>()
            .ReverseMap();
        CreateMap<OrderDetailUpdateDto, OrderDetail>()
            .ReverseMap();
    }

    private void MapOrder()
    {
        CreateMap<Order, OrderGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<OrderGetDto, Order>();
        CreateMap<OrderCreateDto, Order>()
            .ReverseMap();
        CreateMap<OrderUpdateDto, Order>()
            .ReverseMap();
    }

    private void MapMajor()
    {
        CreateMap<Major, MajorGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<MajorGetDto, Major>();
        CreateMap<MajorCreateDto, Major>()
            .ReverseMap();
        CreateMap<MajorUpdateDto, Major>()
            .ReverseMap();
    }

    private void MapInvoiceHistory()
    {
        CreateMap<InvoiceHistory, InvoiceHistoryGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceHistoryGetDto, InvoiceHistory>();
        CreateMap<InvoiceHistoryCreateDto, InvoiceHistory>()
            .ReverseMap();
        CreateMap<InvoiceHistoryUpdateDto, InvoiceHistory>()
            .ReverseMap();
    }

    private void MapInvoice()
    {
        CreateMap<Invoice, InvoiceGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceGetDto, Invoice>();
        CreateMap<InvoiceCreateDto, Invoice>()
            .ReverseMap();
        CreateMap<InvoiceUpdateDto, Invoice>()
            .ReverseMap();
    }

    private void MapFlatType()
    {
        CreateMap<FlatType, FlatTypeGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatTypeGetDto, FlatType>();
        CreateMap<FlatTypeCreateDto, FlatType>()
            .ReverseMap();
        CreateMap<FlatTypeUpdateDto, FlatType>()
            .ReverseMap();
    }

    private void MapFlat()
    {
        CreateMap<Flat, FlatGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatGetDto, Flat>();
        CreateMap<FlatCreateDto, Flat>()
            .ReverseMap();
        CreateMap<FlatUpdateDto, Flat>()
            .ReverseMap();
    }

    private void MapFeedbackType()
    {
        CreateMap<FeedbackType, FeedbackTypeGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FeedbackTypeGetDto, FeedbackType>();
        CreateMap<FeedbackTypeCreateDto, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeUpdateDto, FeedbackType>()
            .ReverseMap();
    }

    private void MapFeedback()
    {
        CreateMap<Feedback, FeedbackGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FeedbackGetDto, Feedback>();
        CreateMap<FeedbackCreateDto, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackUpdateDto, Feedback>()
            .ReverseMap();
    }

    private void MapExpenseType()
    {
        CreateMap<ExpenseType, ExpenseTypeGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ExpenseTypeGetDto, ExpenseType>();
        CreateMap<ExpenseTypeCreateDto, ExpenseType>()
            .ReverseMap();
        CreateMap<ExpenseTypeUpdateDto, ExpenseType>()
            .ReverseMap();
    }

    private void MapExpense()
    {
        CreateMap<Expense, ExpenseGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ExpenseGetDto, Expense>();
        CreateMap<ExpenseCreateDto, Expense>()
            .ReverseMap();
        CreateMap<ExpenseUpdateDto, Expense>()
            .ReverseMap();
    }

    private void MapContractHistory()
    {
        CreateMap<ContractHistory, ContractHistoryGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractHistoryGetDto, ContractHistory>();
        CreateMap<ContractHistoryCreateDto, ContractHistory>()
            .ReverseMap();
        CreateMap<ContractHistoryUpdateDto, ContractHistory>()
            .ReverseMap();
    }

    private void MapContract()
    {
        CreateMap<Contract, ContractGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractGetDto, Contract>();
        CreateMap<ContractCreateDto, Contract>()
            .ReverseMap();
        CreateMap<ContractUpdateDto, Contract>()
            .ReverseMap();
    }

    private void MapBill()
    {
        CreateMap<Bill, BillGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BillGetDto, Bill>();
        CreateMap<BillCreateDto, Bill>()
            .ReverseMap();
        CreateMap<BillUpdateDto, Bill>()
            .ReverseMap();
    }

    private void MapArea()
    {
        CreateMap<Area, AreaGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AreaGetDto, Area>();
        CreateMap<AreaCreateDto, Area>()
            .ReverseMap();
        CreateMap<AreaUpdateDto, Area>()
            .ReverseMap();
    }

    private void MapApartment()
    {
        CreateMap<Apartment, ApartmentGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ApartmentGetDto, Apartment>();
        CreateMap<ApartmentCreateDto, Apartment>()
            .ReverseMap();
        CreateMap<ApartmentUpdateDto, Apartment>()
            .ReverseMap();
    }

    private void MapRenter()
    {
        CreateMap<Renter, RenterGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterGetDto, Renter>();
        CreateMap<RenterCreateDto, Renter>()
            .ReverseMap();
        CreateMap<RenterUpdateDto, Renter>().ReverseMap()
            .ReverseMap();
    }

    private void MapAccount()
    {
        CreateMap<Account, AccountGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AccountGetDto, Account>();
        CreateMap<AccountCreateDto, Account>()
            .ReverseMap();
        CreateMap<AccountUpdateDto, Account>()
            .ReverseMap();
    }

    private void MapBuilding()
    {
        CreateMap<Building, BuildingGetDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BuildingGetDto, Building>();
        CreateMap<BuildingCreateDto, Building>()
            .ReverseMap();
        CreateMap<BuildingUpdateDto, Building>()
            .ReverseMap();
    }
}