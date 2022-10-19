using Application.IRepository;
using Domain.EntitiesForManagement;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class WalletService : IWalletService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public WalletService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            return await _repositoryWrapper.Wallets.CreateWallet(wallet);
        }

        public async Task<bool> DisableWallet(Guid walletId, int accountId)
        {
            return await _repositoryWrapper.Wallets.DisableWallet(walletId, accountId);
        }

        public IQueryable<WalletType> GetAllWalletType()
        {
            return _repositoryWrapper.Wallets.GetAllWalletType();
        }

        public Task<Wallet> GetWalletByAccountIDAndType(int accountID, int type)
        {
            return _repositoryWrapper.Wallets.GetWalletByAccountIDAndType(accountID, type);
        }

        public Task<Wallet> GetWalletByID(Guid walletId)
        {
            return _repositoryWrapper.Wallets.GetWalletByID(walletId);
        }

        public IQueryable<Wallet> GetWalletsByAccountID(int accountID)
        {
            return _repositoryWrapper.Wallets.GetWalletsByAccountID(accountID);
        }

        public async Task<Wallet> UpdateWallet(Wallet wallet)
        {
            return await _repositoryWrapper.Wallets.UpdateWallet(wallet);
        }
    }
}
