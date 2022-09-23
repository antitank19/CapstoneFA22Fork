using Application.IRepository;
using Application.Repository;
using Infrastructure;
using Service.IService;

namespace Service.Service;

public class ServiceWrapper : IServiceWrapper
{
    //private readonly ApplicationContext context;
    private readonly IRepositoryWrapper reposities;

    public ServiceWrapper(IRepositoryWrapper? reposities, ApplicationContext? context)
    {
        if (reposities == null)
        {
            if (context == null)
                throw new ArgumentNullException(
                    $"Provide neither {nameof(reposities)} nor {nameof(context)}!\nCheck Dependency Injection");
            reposities = new RepositoryWrapper(context);
        }
        else
        {
            this.reposities = reposities;
        }
    }

    /*
    public IDistrictService Districts
    {
        get
        {
            if (districts == null)
            {
                districts = new DistrictService(reposities);
            }
            return districts;
        }
    }

    public IOwnerService Owners
    {
        get
        {
            if (owners == null)
            {
                owners = new OwnerService(reposities);
            }
            return owners;
        }
    }

    public IPaymentService Payments
    {
        get
        {
            if (payments == null)
            {
                payments = new PaymentService(reposities);
            }
            return payments;
        }
    }

    public IPaymentTypeService PaymentTypes
    {
        get
        {
            if (paymentTypes == null)
            {
                paymentTypes = new PaymentTypeService(reposities);
            }
            return paymentTypes;
        }
    }

    public IRentEntityService RentEntities
    {
        get
        {
            if (rentEntities == null)
            {
                rentEntities = new RentEntityService(reposities);
            }
            return rentEntities;
        }
    }

    public IRoleService Roles
    {
        get
        {
            if (roles == null)
            {
                roles = new RoleService(reposities);
            }
            return roles;
        }
    }

    public IRoomService Rooms
    {
        get
        {
            if (rooms == null)
            {
                rooms = new RoomService(reposities);
            }
            return rooms;
        }
    }

    public IRoomTypeService RoomTypes
    {
        get
        {
            if (roomTypes == null)
            {
                roomTypes = new RoomTypeService(reposities);
            }
            return roomTypes;
        }
    }

    public ITransactionService Transactions
    {
        get
        {
            if (transactions == null)
            {
                transactions = new TransactionService(reposities);
            }
            return transactions;
        }
    }

    public IUniversityService Universities
    {
        get
        {
            if (universities == null)
            {
                universities = new UniversityService(reposities);
            }
            return universities;
        }
    }

    public IUserService Users
    {
        get
        {
            if (users == null)
            {
                users = new UserService(reposities);
            }
            return users;
        }
    }

    public IWardService Wards
    {
        get
        {
            if (wards == null)
            {
                wards = new WardService(reposities);
            }
            return wards;
        }
    }
    */

    public ITokenService Tokens => throw new NotImplementedException();

    public IBuildingService Buildings
    {
        get
        {
            if (buildings == null) buildings = new BuildingService(reposities);
            return buildings;
        }
    }

    public ICityService Cities
    {
        get
        {
            if (cities == null) cities = new CityService(reposities);
            return cities;
        }
    }

    public IContractService Contracts
    {
        get
        {
            if (contracts == null) contracts = new ContractService(reposities);
            return contracts;
        }
    }

    public IContractHistoryService ContractHistories
    {
        get
        {
            if (contractHistories == null) contractHistories = new ContractHistoryService(reposities);
            return contractHistories;
        }
    }

    #region fields

    private IBuildingService buildings;
    private ICityService cities;
    private IContractService contracts;
    private IContractHistoryService contractHistories;
    private IDistrictService districts;
    private IOwnerService owners;
    private IPaymentService payments;
    private IPaymentTypeService paymentTypes;
    private IRentEntityService rentEntities;
    private IRoleService roles;
    private IRoomService rooms;
    private IRoomTypeService roomTypes;
    private ITransactionService transactions;
    private IUniversityService universities;
    private IUserService users;
    private IWardService wards;
    private ITokenService tokens;

    #endregion
}