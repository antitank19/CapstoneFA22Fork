using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    internal interface IReposityWrapper
    {
        internal IBuildingRepository Buildings { get; }
        internal ICityRepository Cities { get; }
        internal IContractRepository Contracts { get; }
        internal IContractHistoryRepository ContractHistories { get; }
        internal IDistrictRepository Districts { get; }
        internal IOwnerRepository Owners { get; }
        internal IPaymentRepository Payments { get; }
        internal IPaymentTypeRepository PaymentTypes { get; }
        internal IRentEntityRepository RentEntities { get; }
        internal IRoleRepository Roles { get; }
        internal IRoomRepository Rooms { get; }
        internal IRoomTypeRepository RoomTypes { get; }
        internal ITransactionRepository Transactions { get; }
        internal IUniversityRepository Universities { get; }
        internal IUserRepository Users { get; }
        internal IWardRepository Wards { get; }
    }
}
