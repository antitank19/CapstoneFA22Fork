using Application.IRepository;
using Infrastructure;

namespace Application.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ApplicationContext context;

    public RepositoryWrapper(ApplicationContext context)
    {
        this.context = context;
    }

    public IAccountRepository Accounts
    {
        get
        {
            if (accounts == null) accounts = new AccountRepository(context);
            return accounts;
        }
    }
    public IAppartmentRepository Appartments
    {
        get
        {
            if (appartments == null) appartments = new AppartmentRepository(context);
            return appartments;
        }
    }
    public IAreaRepository Areas
    {
        get
        {
            if (areas == null) areas = new AreaRepository(context);
            return areas;
        }
    }

    public IBillRepository Bills
    {
        get
        {
            if (bills == null) bills = new BillRepository(context);
            return bills;
        }
    }
    public IBuildingRepository Buildings
    {
        get
        {
            if (buildings == null) buildings = new BuildingRepository(context);
            return buildings;
        }
    }

    public IContractRepository Contracts
    {
        get
        {
            if (contracts == null) contracts = new ContractRepository(context);
            return contracts;
        }
    }

    public IContractHistoryRepository ContractHistories
    {
        get
        {
            if (contractHistories == null) contractHistories = new ContractHistoryRepository(context);
            return contractHistories;
        }
    }

    public IExpenseRepository Expenses
    {
        get
        {
            if (expenses == null) expenses = new ExpenseRepository(context);
            return expenses;
        }
    }
    public IExpenseHistoryRepository ExpenseHistories
    {
        get
        {
            if (expenseHistories == null) expenseHistories = new ExpenseHistoryRepository(context);
            return expenseHistories;
        }
    }

    public IExpenseTypeRepository ExpenseTypes
    {
        get
        {
            if (expenseTypes == null) expenseTypes = new ExpenseTypeRepository(context);
            return expenseTypes;
        }
    }

    public IFeedbackRepository Feedbacks
    {
        get
        {
            if (feedbacks == null) feedbacks = new FeedbackRepository(context);
            return feedbacks;
        }
    }
    public IFeedbackTypeRepository FeedbackTypes
    {
        get
        {
            if (feedbackTypes == null) feedbackTypes = new FeedbackTypeRepository(context);
            return feedbackTypes;
        }
    }

    public IFlatRepository Flats
    {
        get
        {
            if (flats == null) flats = new FlatRepository(context);
            return flats;
        }
    }

    public IFlatTypeRepository FlatTypes
    {
        get
        {
            if (flatTypes == null) flatTypes = new FlatTypeRepository(context);
            return flatTypes;
        }
    }

    public IInvoiceRepository Invoices
    {
        get
        {
            if (invoices == null) invoices = new InvoiceRepository(context);
            return invoices;
        }
    }

    public IInvoiceHistoryRepository InvoiceHistories
    {
        get
        {
            if (invoiceHistories == null) invoiceHistories = new InvoiceHistoryRepository(context);
            return invoiceHistories;
        }
    }

    public IMajorRepository Majors
    {
        get
        {
            if (majors == null) majors = new MajorRepository(context);
            return majors;
        }
    }

    public IOrderRepository Orders
    {
        get
        {
            if (orders == null) orders = new OrderRepository(context);
            return orders;
        }
    }

    public IOrderDetailRepository OrderDetails
    {
        get
        {
            if (orderDetails == null) orderDetails = new OrderDetailRepository(context);
            return orderDetails;
        }
    }

    public IPaymentRepository Payments
    {
        get
        {
            if (payments == null) payments = new PaymentRepository(context);
            return payments;
        }
    }
    public IPaymentTypeRepository PaymentTypes
    {
        get
        {
            if (paymentTypes == null) paymentTypes = new PaymentTypeRepository(context);
            return paymentTypes;
        }
    }

    public IRenterRepository Renters
    {
        get
        {
            if (renters == null) renters = new RenterRepository(context);
            return renters;
        }
    }

    public IRequestRepository Requests
    {
        get
        {
            if (requests == null) requests = new RequestRepository(context);
            return requests;
        }
    }
    public IRequestTypeRepository RequestTypes
    {
        get
        {
            if (requestTypes == null) requestTypes = new RequestTypeRepository(context);
            return requestTypes;
        }
    }

    public IRoleRepository Roles
    {
        get
        {
            if (roles == null) roles = new RoleRepository(context);
            return roles;
        }
    }
    public IServiceRepository Services
    {
        get
        {
            if (services == null) services = new ServiceRepository(context);
            return services;
        }
    }
    public IServiceTypeRepository ServiceTypes
    {
        get
        {
            if (serviceTypes == null) serviceTypes = new ServiceTypeRepository(context);
            return serviceTypes;
        }
    }
    public IUniversityRepository Universities
    {
        get
        {
            if (universities == null) universities = new UniversityRepository(context);
            return universities;
        }
    }


    #region fields

    private IAccountRepository accounts;
    private IAppartmentRepository appartments;
    private IAreaRepository areas;
    private IBillRepository bills;
    private IBuildingRepository buildings;
    private IContractRepository contracts;
    private IContractHistoryRepository contractHistories;
    private IExpenseRepository expenses;
    private IExpenseHistoryRepository expenseHistories;
    private IExpenseTypeRepository expenseTypes;    
    private IFeedbackRepository feedbacks;
    private IFeedbackTypeRepository feedbackTypes;
    private IFlatRepository flats;
    private IFlatTypeRepository flatTypes;
    private IInvoiceRepository invoices;
    private IInvoiceHistoryRepository invoiceHistories;
    private IMajorRepository majors;
    private IOrderRepository orders;
    private IOrderDetailRepository orderDetails;
    private IPaymentRepository payments;
    private IPaymentTypeRepository paymentTypes;
    private IRenterRepository renters;
    private IRequestRepository requests;
    private IRequestTypeRepository requestTypes;
    private IRoleRepository roles;
    private IServiceRepository services;
    private IServiceTypeRepository serviceTypes;
    private IUniversityRepository universities;

    #endregion
}