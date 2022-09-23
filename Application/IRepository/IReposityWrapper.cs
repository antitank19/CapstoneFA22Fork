namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IBuildingRepository Buildings { get; }
    public ICityRepository Cities { get; }
    public IContractRepository Contracts { get; }
    public IContractHistoryRepository ContractHistories { get; }
    public IDistrictRepository Districts { get; }
    public IOwnerRepository Owners { get; }
    public IPaymentRepository Payments { get; }
    public IPaymentTypeRepository PaymentTypes { get; }
    public IRentEntityRepository RentEntities { get; }
    public IRoleRepository Roles { get; }
    public IRoomRepository Rooms { get; }
    public IRoomTypeRepository RoomTypes { get; }
    public ITransactionRepository Transactions { get; }
    public IUniversityRepository Universities { get; }
    public IUserRepository Users { get; }
    public IWardRepository Wards { get; }
}