using Application.IRepository;
using Application.IRepository;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    internal class RepsitoryWrapper  : IReposityWrapper
    {
        private readonly ApplicationContext context;

        public RepsitoryWrapper(ApplicationContext context)
        {
            this.context = context;
        }
        #region   fields
        private IBuildingRepository buildings ;
        private ICityRepository cities ;
        private IContractRepository contracts ;
        private IContractHistoryRepository contractHistories ;
        private IDistrictRepository districts ;
        private IOwnerRepository owners ;
        private IPaymentRepository payments ;
        private IPaymentTypeRepository paymentTypes ;
        private IRentEntityRepository rentEntities ;
        private IRoleRepository roles ;
        private IRoomRepository rooms ;
        private IRoomTypeRepository roomTypes ;
        private ITransactionRepository transactions ;
        private IUniversityRepository universities ;
        private IUserRepository users ;
        private IWardRepository wards ;
        #endregion 

        public IBuildingRepository Buildings
        {
            get
            {
                if (buildings == null)
                {
                    buildings = new BuildingRepository(context);
                }
                return buildings;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                if (cities == null)
                {
                    cities = new CityRepository(context);
                }
                return cities;
            }
        }

        public IContractRepository Contracts
        {
            get
            {
                if (contracts == null)
                {
                    contracts = new ContractRepository(context);
                }
                return contracts;
            }
        }

        public IContractHistoryRepository ContractHistories
        {
            get
            {
                if (contractHistories == null)
                {
                    contractHistories = new ContractHistoryRepository(context);
                }
                return contractHistories;
            }
        }

        public IDistrictRepository Districts
        {
            get
            {
                if (districts == null)
                {
                    districts = new DistrictRepository(context);
                }
                return districts;
            }
        }

        public IOwnerRepository Owners
        {
            get
            {
                if (owners == null)
                {
                    owners = new OwnerRepository(context);
                }
                return owners;
            }
        }

        public IPaymentRepository Payments
        {
            get
            {
                if (payments == null)
                {
                    payments = new PaymentRepository(context);
                }
                return payments;
            }
        }

        public IPaymentTypeRepository PaymentTypes
        {
            get
            {
                if (paymentTypes == null)
                {
                    paymentTypes = new PaymentTypeRepository(context);
                }
                return paymentTypes;
            }
        }

        public IRentEntityRepository RentEntities
        {
            get
            {
                if (rentEntities == null)
                {
                    rentEntities = new RentEntityRepository(context);
                }
                return rentEntities;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roles == null)
                {
                    roles = new RoleRepository(context);
                }
                return roles;
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                if (rooms == null)
                {
                    rooms = new RoomRepository(context);
                }
                return rooms;
            }
        }

        public IRoomTypeRepository RoomTypes
        {
            get
            {
                if (roomTypes == null)
                {
                    roomTypes = new RoomTypeRepository(context);
                }
                return roomTypes;
            }
        }

        public ITransactionRepository Transactions
        {
            get
            {
                if (transactions == null)
                {
                    transactions = new TransactionRepository(context);
                }
                return transactions;
            }
        }

        public IUniversityRepository Universities
        {
            get
            {
                if (universities == null)
                {
                    universities = new UniversityRepository(context);
                }
                return universities;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (users == null)
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        public IWardRepository Wards
        {
            get
            {
                if (wards == null)
                {
                    wards = new WardRepository(context);
                }
                return wards;
            }
        }
    }
}
