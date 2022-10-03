namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IBuildingRepository Buildings { get; }
    public ICityRepository Cities { get; }
    public IContractRepository Contracts { get; }
    public IContractHistoryRepository ContractHistories { get; }
    public IDistrictRepository Districts { get; }
    public IPaymentRepository Payments { get; }
    public IPaymentTypeRepository PaymentTypes { get; }
    public IRoleRepository Roles { get; }
    public IFlatRepository Rooms { get; }
    public IFlatTypeRepository RoomTypes { get; }
    public IBillRepository Bills { get; }
    public IUniversityRepository Universities { get; }
    public IRenterRepository Renters { get; }
    public IAccountRepository Accounts { get; }
}