using Application.IRepository;
using Infrastructure;

namespace Application.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationContext _context;

    public RepositoryWrapper(ApplicationContext context)
    {
        _context = context;
    }

    public IAccountRepository Accounts
    {
        get
        {
            if (_accounts == null) _accounts = new AccountRepository(_context);
            return _accounts;
        }
    }

    public IApartmentRepository Apartments
    {
        get
        {
            if (_apartments == null) _apartments = new ApartmentRepository(_context);
            return _apartments;
        }
    }

    public IAreaRepository Areas
    {
        get
        {
            if (_areas == null) _areas = new AreaRepository(_context);
            return _areas;
        }
    }

    public IBillRepository Bills
    {
        get
        {
            if (_bills == null) _bills = new BillRepository(_context);
            return _bills;
        }
    }

    public IBuildingRepository Buildings
    {
        get
        {
            if (_buildings == null) _buildings = new BuildingRepository(_context);
            return _buildings;
        }
    }

    public IContractRepository Contracts
    {
        get
        {
            if (_contracts == null) _contracts = new ContractRepository(_context);
            return _contracts;
        }
    }

    public IContractHistoryRepository ContractHistories
    {
        get
        {
            if (_contractHistories == null) _contractHistories = new ContractHistoryRepository(_context);
            return _contractHistories;
        }
    }

    public IExpenseRepository Expenses
    {
        get
        {
            if (_expenses == null) _expenses = new ExpenseRepository(_context);
            return _expenses;
        }
    }

    public IExpenseHistoryRepository ExpenseHistories
    {
        get
        {
            if (_expenseHistories == null) _expenseHistories = new ExpenseHistoryRepository(_context);
            return _expenseHistories;
        }
    }

    public IExpenseTypeRepository ExpenseTypes
    {
        get
        {
            if (_expenseTypes == null) _expenseTypes = new ExpenseTypeRepository(_context);
            return _expenseTypes;
        }
    }

    public IFeedbackRepository Feedbacks
    {
        get
        {
            if (_feedbacks == null) _feedbacks = new FeedbackRepository(_context);
            return _feedbacks;
        }
    }

    public IFeedbackTypeRepository FeedbackTypes
    {
        get
        {
            if (_feedbackTypes == null) _feedbackTypes = new FeedbackTypeRepository(_context);
            return _feedbackTypes;
        }
    }

    public IFlatRepository Flats
    {
        get
        {
            if (_flats == null) _flats = new FlatRepository(_context);
            return _flats;
        }
    }

    public IFlatTypeRepository FlatTypes
    {
        get
        {
            if (_flatTypes == null) _flatTypes = new FlatTypeRepository(_context);
            return _flatTypes;
        }
    }

    public IInvoiceRepository Invoices
    {
        get
        {
            if (_invoices == null) _invoices = new InvoiceRepository(_context);
            return _invoices;
        }
    }

    public IInvoiceHistoryRepository InvoiceHistories
    {
        get
        {
            if (_invoiceHistories == null) _invoiceHistories = new InvoiceHistoryRepository(_context);
            return _invoiceHistories;
        }
    }

    public IMajorRepository Majors
    {
        get
        {
            if (_majors == null) _majors = new MajorRepository(_context);
            return _majors;
        }
    }

    public IOrderRepository Orders
    {
        get
        {
            if (_orders == null) _orders = new OrderRepository(_context);
            return _orders;
        }
    }

    public IOrderDetailRepository OrderDetails
    {
        get
        {
            if (_orderDetails == null) _orderDetails = new OrderDetailRepository(_context);
            return _orderDetails;
        }
    }

    public IPaymentRepository Payments
    {
        get
        {
            if (_payments == null) _payments = new PaymentRepository(_context);
            return _payments;
        }
    }

    public IPaymentTypeRepository PaymentTypes
    {
        get
        {
            if (_paymentTypes == null) _paymentTypes = new PaymentTypeRepository(_context);
            return _paymentTypes;
        }
    }

    public IRenterRepository Renters
    {
        get
        {
            if (_renters == null) _renters = new RenterRepository(_context);
            return _renters;
        }
    }

    public IRequestRepository Requests
    {
        get
        {
            if (_requests == null) _requests = new RequestRepository(_context);
            return _requests;
        }
    }

    public IRequestTypeRepository RequestTypes
    {
        get
        {
            if (_requestTypes == null) _requestTypes = new RequestTypeRepository(_context);
            return _requestTypes;
        }
    }

    public IRoleRepository Roles
    {
        get
        {
            if (_roles == null) _roles = new RoleRepository(_context);
            return _roles;
        }
    }

    public IServiceEntityRepository ServiceEntities
    {
        get
        {
            if (_servicesEntity == null) _servicesEntity = new ServiceEntityRepository(_context);
            return _servicesEntity;
        }
    }

    public IServiceTypeRepository ServiceTypes
    {
        get
        {
            if (_serviceTypes == null) _serviceTypes = new ServiceTypeRepository(_context);
            return _serviceTypes;
        }
    }

    public IUniversityRepository Universities
    {
        get
        {
            if (_universities == null) _universities = new UniversityRepository(_context);
            return _universities;
        }
    }

    #region fields

    private IAccountRepository _accounts;
    private IApartmentRepository _apartments;
    private IAreaRepository _areas;
    private IBillRepository _bills;
    private IBuildingRepository _buildings;
    private IContractHistoryRepository _contractHistories;
    private IContractRepository _contracts;
    private IExpenseHistoryRepository _expenseHistories;
    private IExpenseRepository _expenses;
    private IExpenseTypeRepository _expenseTypes;
    private IFeedbackRepository _feedbacks;
    private IFeedbackTypeRepository _feedbackTypes;
    private IFlatRepository _flats;
    private IFlatTypeRepository _flatTypes;
    private IInvoiceHistoryRepository _invoiceHistories;
    private IInvoiceRepository _invoices;
    private IMajorRepository _majors;
    private IOrderDetailRepository _orderDetails;
    private IOrderRepository _orders;
    private IPaymentRepository _payments;
    private IPaymentTypeRepository _paymentTypes;
    private IRenterRepository _renters;
    private IRequestRepository _requests;
    private IRequestTypeRepository _requestTypes;
    private IRoleRepository _roles;
    private IServiceEntityRepository _servicesEntity;
    private IServiceTypeRepository _serviceTypes;
    private IUniversityRepository _universities;

    #endregion
}