using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IWalletRepository
    {
        public IQueryable<WalletType> GetAllWalletType();
        public IQueryable<Wallet> GetWalletsByAccountID(int accountID);
        public Task<Wallet> GetWalletByAccountIDAndType(int accountID, int type);
        public Task<Wallet> GetWalletByID(Guid walletId);
        public Task<Wallet> CreateWallet(Wallet wallet);
        public Task<Wallet> UpdateWallet(Wallet wallet);
        public Task<bool> DisableWallet(Guid walletId, int accountId);

    }
}
