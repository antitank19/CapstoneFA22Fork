namespace Service.IService;

public interface IServiceWrapper
{
    public IAccountService Accounts { get; }
    public IApartmentService Apartments { get; }
    public IAreaService Areas { get; }
    public IBillService Bills { get; }
    public IBuildingService Buildings { get; }
    public IContractHistoryService ContractHistories { get; }
    public IContractService Contracts { get; }
    public IExpenseHistoryService ExpenseHistories { get; }
    public IExpenseService Expenses { get; }
    public IExpenseTypeService ExpenseTypes { get; }
    public IFeedbackService Feedbacks { get; }
    public IFeedbackTypeService FeedbackTypes { get; }
    public IFlatService Flats { get; }
    public IFlatTypeService FlatTypes { get; }
    public IInvoiceHistoryService InvoiceHistories { get; }
    public IInvoiceService Invoices { get; }
    public IMajorService Majors { get; }
    public IOrderDetailService OrderDetails { get; }
    public IOrderService Orders { get; }
    public IPaymentService Payments { get; }
    public IPaymentTypeService PaymentTypes { get; }
    public IRenterService Renters { get; }
    public IRequestService Requests { get; }
    public IRequestTypeService RequestTypes { get; }
    public IRoleService Roles { get; }
    public ITokenService Tokens { get; }
    public IServiceEntityService ServicesEntity { get; }
    public IServiceTypeService ServiceTypes { get; }
    public IUniversityService Universities { get; }
}