namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IAccountRepository Accounts { get; }
    public IAppartmentRepository Appartments { get; }
    public IAreaRepository Areas { get; }
    public IBillRepository Bills { get; }
    public IBuildingRepository Buildings { get; }
    public IContractRepository Contracts { get; }
    public IContractHistoryRepository ContractHistories { get; }
    public IExpenseRepository Expenses { get; }
    public IExpenseHistoryRepository ExpenseHistories { get; }
    public IExpenseTypeRepository ExpenseTypes { get; }
    public IFeedbackRepository Feedbacks { get; }
    public IFeedbackTypeRepository FeedbackTypes { get; }
    public IFlatRepository Flats { get; }
    public IFlatTypeRepository FlatTypes { get; }
    public IInvoiceRepository Invoices { get; }
    public IInvoiceHistoryRepository InvoiceHistories { get; }
    public IMajorRepository Majors { get; }
    public IOrderRepository Orders { get; }
    public IOrderDetailRepository OrderDetails { get; }
    public IPaymentRepository Payments { get; }
    public IPaymentTypeRepository PaymentTypes { get; }
    public IRenterRepository Renters { get; }
    public IRequestRepository Requests { get; }
    public IRequestTypeRepository RequestTypes { get; }
    public IRoleRepository Roles { get; }
    public IServiceRepository Services { get; }
    public IServiceTypeRepository ServiceTypes { get; }
    public IUniversityRepository Universities { get; }
}