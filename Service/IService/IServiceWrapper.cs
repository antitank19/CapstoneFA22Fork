namespace Service.IService;

public interface IServiceWrapper
{
    public IBuildingService Buildings { get; }
    public ICityService Cities { get; }
    public IContractService Contracts { get; }

    public IContractHistoryService ContractHistories { get; }
    /*
public IDistrictService Districts { get; }
public IOwnerService Owners { get; }
public IPaymentService Payments { get; }
public IPaymentTypeService PaymentTypes { get; }
public IRentEntityService RentEntities { get; }
public IRoleService Roles { get; }
public IRoomService Rooms { get; }
public IRoomTypeService RoomTypes { get; }
public ITokenService Tokens { get; }
public ITransactionService Transactions { get; }
public IUniversityService Universities { get; }
public IUserService Users { get; }
public IWardService Wards { get; }
*/
}