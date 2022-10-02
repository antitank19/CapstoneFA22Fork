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

    public IBuildingRepository Buildings
    {
        get
        {
            if (buildings == null) buildings = new BuildingRepository(context);
            return buildings;
        }
    }

    public ICityRepository Cities
    {
        get
        {
            if (cities == null) cities = new CityRepository(context);
            return cities;
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

    public IDistrictRepository Districts
    {
        get
        {
            if (districts == null) districts = new DistrictRepository(context);
            return districts;
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

    public IRoleRepository Roles
    {
        get
        {
            if (roles == null) roles = new RoleRepository(context);
            return roles;
        }
    }

    public IFlatRepository Rooms
    {
        get
        {
            if (rooms == null) rooms = new FlatRepository(context);
            return rooms;
        }
    }

    public IFlatTypeRepository RoomTypes
    {
        get
        {
            if (roomTypes == null) roomTypes = new FlatTypeRepository(context);
            return roomTypes;
        }
    }

    public IBillRepository Bills
    {
        get
        {
            if (transactions == null) transactions = new BillRepository(context);
            return transactions;
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

    public IUserRepository Users
    {
        get
        {
            if (users == null) users = new UserRepository(context);
            return users;
        }
    }

    public IWardRepository Wards
    {
        get
        {
            if (wards == null) wards = new WardRepository(context);
            return wards;
        }
    }

    #region fields

    private IBuildingRepository buildings;
    private ICityRepository cities;
    private IContractRepository contracts;
    private IContractHistoryRepository contractHistories;
    private IDistrictRepository districts;
    private IPaymentRepository payments;
    private IPaymentTypeRepository paymentTypes;
    private IRoleRepository roles;
    private IFlatRepository rooms;
    private IFlatTypeRepository roomTypes;
    private IBillRepository transactions;
    private IUniversityRepository universities;
    private IUserRepository users;
    private IWardRepository wards;

    #endregion
}