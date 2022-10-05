using Application.IRepository;
using Application.Repository;
using Infrastructure;
using Service.IService;

namespace Service.Service;

public class ServiceWrapper : IServiceWrapper
{
    //private readonly ApplicationContext context;
    private readonly IRepositoryWrapper repositories;

    public ServiceWrapper(IRepositoryWrapper? repositories, ApplicationContext? context)
    {
        if (repositories == null)
        {
            if (context == null)
                throw new ArgumentNullException(
                    $"Provide neither {nameof(repositories)} nor {nameof(context)}!\nCheck Dependency Injection");
            _ = new RepositoryWrapper(context);
        }
        else
        {
            this.repositories = repositories;
        }
    }

    public ITokenService Tokens { get; set; }


    public IAccountService Accounts
    {
        get
        {
            if (_account == null) _account = new AccountService(repositories);
            return _account;
        }
    }

    public IApartmentService Apartments
    {
        get
        {
            if (_apartment == null) _apartment = new ApartmentService(repositories);
            return _apartment;
        }
    }

    public IAreaService Areas
    {
        get
        {
            if (_area == null) _area = new AreaService(repositories);
            return _area;
        }
    }

    public IBillService Bills
    {
        get
        {
            if (_bill == null) _bill = new BillService(repositories);
            return _bill;
        }
    }

    public IBuildingService Buildings
    {
        get
        {
            if (_building == null) _building = new BuildingService(repositories);
            return _building;
        }
    }

    public IContractHistoryService ContractHistories
    {
        get
        {
            if (_contractHistories == null) _contractHistories = new ContractHistoryService(repositories);
            return _contractHistories;
        }
    }

    public IContractService Contracts
    {
        get
        {
            if (_contracts == null) _contracts = new ContractService(repositories);
            return _contracts;
        }
    }

    public IExpenseHistoryService ExpenseHistories
    {
        get
        {
            if (_expenseHistory == null) _expenseHistory = new ExpenseHistoryService(repositories);
            return _expenseHistory;
        }
    }

    public IExpenseService Expenses
    {
        get
        {
            if (_expense == null) _expense = new ExpenseService(repositories);
            return _expense;
        }
    }

    public IExpenseTypeService ExpenseTypes
    {
        get
        {
            if (_expenseType == null) _expenseType = new ExpenseTypeService(repositories);
            return _expenseType;
        }
    }

    public IFeedbackService Feedbacks
    {
        get
        {
            if (_feedback == null) _feedback = new FeedbackService(repositories);
            return _feedback;
        }
    }

    public IFeedbackTypeService FeedbackTypes
    {
        get
        {
            if (_feedbackType == null) _feedbackType = new FeedbackTypeService(repositories);
            return _feedbackType;
        }
    }

    public IFlatService Flats
    {
        get
        {
            if (_flat == null) _flat = new FlatService(repositories);
            return _flat;
        }
    }

    public IFlatTypeService FlatTypes
    {
        get
        {
            if (_flatType == null) _flatType = new FlatTypeService(repositories);
            return _flatType;
        }
    }

    public IInvoiceHistoryService InvoiceHistories
    {
        get
        {
            if (_invoiceHistory == null) _invoiceHistory = new InvoiceHistoryService(repositories);
            return _invoiceHistory;
        }
    }

    public IInvoiceService Invoices
    {
        get
        {
            if (_invoice == null) _invoice = new InvoiceService(repositories);
            return _invoice;
        }
    }

    public IMajorService Majors
    {
        get
        {
            if (_major == null) _major = new MajorService(repositories);
            return _major;
        }
    }

    public IOrderDetailService OrderDetails
    {
        get
        {
            if (_orderDetail == null) _orderDetail = new OrderDetailService(repositories);
            return _orderDetail;
        }
    }

    public IOrderService Orders
    {
        get
        {
            if (_order == null) _order = new OrderService(repositories);
            return _order;
        }
    }

    public IPaymentService Payments
    {
        get
        {
            if (_payment == null) _payment = new PaymentService(repositories);
            return _payment;
        }
    }

    public IPaymentTypeService PaymentTypes
    {
        get
        {
            if (_paymentType == null) _paymentType = new PaymentTypeService(repositories);
            return _paymentType;
        }
    }

    public IRenterService Renters
    {
        get
        {
            if (_renter == null) _renter = new RenterService(repositories);
            return _renter;
        }
    }

    public IRoleService Roles
    {
        get
        {
            if (_roles == null) _roles = new RoleService(repositories);
            return _roles;
        }
    }

    public IRequestService Requests
    {
        get
        {
            if (_request == null) _request = new RequestService(repositories);
            return _request;
        }
    }

    public IRequestTypeService RequestTypes
    {
        get
        {
            if (_requestType == null) _requestType = new RequestTypeService(repositories);
            return _requestType;
        }
    }

    public IServiceEntityService ServicesEntity
    {
        get
        {
            if (_serviceEntity == null) _serviceEntity = new ServiceEntityService(repositories);
            return _serviceEntity;
        }
    }

    public IServiceTypeService ServiceTypes
    {
        get
        {
            if (_serviceType == null) _serviceType = new ServiceTypeService(repositories);
            return _serviceType;
        }
    }

    public IUniversityService Universities
    {
        get
        {
            if (_universities == null) _universities = new UniversityService(repositories);
            return _universities;
        }
    }

    #region fields

    private IAccountService _account;
    private IApartmentService _apartment;
    private IAreaService _area;
    private IBillService _bill;
    private IBuildingService _building;
    private IContractHistoryService _contractHistories;
    private IContractService _contracts;
    private IExpenseHistoryService _expenseHistory;
    private IExpenseService _expense;
    private IExpenseTypeService _expenseType;
    private IFeedbackService _feedback;
    private IFeedbackTypeService _feedbackType;
    private IFlatService _flat;
    private IFlatTypeService _flatType;
    private IInvoiceHistoryService _invoiceHistory;
    private IInvoiceService _invoice;
    private IMajorService _major;
    private IOrderDetailService _orderDetail;
    private IOrderService _order;
    private IPaymentService _payment;
    private IPaymentTypeService _paymentType;
    private IRenterService _renter;
    private IRequestService _request;
    private IRequestTypeService _requestType;
    private IRoleService _roles;
    private IServiceEntityService _serviceEntity;
    private IServiceTypeService _serviceType;
    private IUniversityService _universities;
    private ITokenService tokens;

    #endregion
}