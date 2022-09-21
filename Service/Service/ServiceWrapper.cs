using Application.IRepository;
using Application.Repository;
using Infrastructure;
using Service.IService;

namespace Service.Service
{
    public class ServiceWrapper : IServiceWrapper
    {
        //private readonly ApplicationContext context;
        private readonly IRepositoryWrapper reposities;

        public ServiceWrapper(IRepositoryWrapper? reposities, ApplicationContext? context)
        {
            if (reposities == null)
            {
                if (context == null)
                {
                    throw new ArgumentNullException($"Provide neither {nameof(reposities)} nor {nameof(context)}!\nCheck Dependency Injection");
                }
                reposities = new RepositoryWrapper(context);
            }
            else
            {
                this.reposities = reposities;
            }

        }

        #region   fields
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

        public IBuildingService Buildings
        {
            get
            {
                if (buildings == null)
                {
                    buildings = new Service.BuildingService(reposities);
                }
                return buildings;
            }
        }

        public ICityService Cities
        {
            get
            {
                if (cities == null)
                {
                    cities = new Application.Service.CityService(reposities);
                }
                return cities;
            }
        }

        public IContractService Contracts
        {
            get
            {
                if (contracts == null)
                {
                    contracts = new Application.Service.ContractService(reposities);
                }
                return contracts;
            }
        }

        public IContractHistoryService ContractHistories
        {
            get
            {
                if (contractHistories == null)
                {
                    contractHistories = new ContractHistoryService(reposities);
                }
                return contractHistories;
            }
        }

        public IDistrictService Districts
        {
            get
            {
                if (districts == null)
                {
                    districts = new Application.Service.DistrictService(reposities);
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
                    owners = new Application.Service.OwnerService(reposities);
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
                    payments = new Application.Service.PaymentService(reposities);
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
                    paymentTypes = new Application.Service.PaymentTypeService(reposities);
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
                    rentEntities = new Application.Service.RentEntityService(reposities);
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
                    roles = new Application.Service.RoleService(reposities);
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
                    rooms = new Application.Service.RoomService(reposities);
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
                    roomTypes = new Application.Service.RoomTypeService(reposities);
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
                    transactions = new Application.Service.TransactionService(reposities);
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
                    universities = new Application.Service.UniversityService(reposities);
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
                    users = new Application.Service.UserService(reposities);
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
                    wards = new Application.Service.WardService(reposities);
                }
                return wards;
            }
        }

        public ITokenService Tokens => throw new NotImplementedException();
    }
}
