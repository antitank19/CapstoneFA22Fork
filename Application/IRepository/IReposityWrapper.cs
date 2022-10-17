namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IAccountRepository Accounts { get; }
    public IApartmentRepository Apartments { get; }
    public IAreaRepository Areas { get; }
    public IBillRepository Bills { get; }
    public IBuildingRepository Buildings { get; }
    public IContractHistoryRepository ContractHistories { get; }
    public IContractRepository Contracts { get; }
    public IExpenseHistoryRepository ExpenseHistories { get; }
    public IExpenseRepository Expenses { get; }
    public IExpenseTypeRepository ExpenseTypes { get; }
    public IFeedbackTypeRepository FeedbackTypes { get; }
    public IFeedbackRepository Feedbacks { get; }
    public IFlatRepository Flats { get; }
    public IFlatTypeRepository FlatTypes { get; }
    public IInvoiceHistoryRepository InvoiceHistories { get; }
    public IInvoiceRepository Invoices { get; }
    public IMajorRepository Majors { get; }
    public IOrderDetailRepository OrderDetails { get; }
    public IOrderRepository Orders { get; }
    public IPaymentRepository Payments { get; }
    public IPaymentTypeRepository PaymentTypes { get; }
    public IRenterRepository Renters { get; }
    public IRequestRepository Requests { get; }
    public IRequestTypeRepository RequestTypes { get; }
    public IRoleRepository Roles { get; }
    public IServiceEntityRepository ServiceEntities { get; }
    public IServiceTypeRepository ServiceTypes { get; }
    public IUniversityRepository Universities { get; }
    public IWalletRepository Wallets { get; }
}