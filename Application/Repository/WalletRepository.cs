using Application.IRepository;
using Domain.EntitiesForManagement;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationContext _context;
        public WalletRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
            var newWallet = await _context.Wallets.Where(w => w.WalletId == wallet.WalletId).AsNoTracking().FirstOrDefaultAsync();
            return newWallet;
        }

        public async Task<bool> DisableWallet(Guid walletId)
        {
            var wallet = await _context.Wallets.Where(w => w.WalletId == walletId).FirstOrDefaultAsync();
            if (wallet == null) return false;
            wallet.Status = 0;
            _context.Wallets.Update(wallet);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<WalletType> GetAllWalletType()
        {
            var query = _context.WalletTypes;
            return query;
        }

        public IQueryable<Wallet> GetWalletsByAccountID(int accountID)
        {
            var query = _context.Wallets.Include(w => w.WalletType)
                .Where(w => w.Status == 1 && w.AccountId == accountID);
            return query;
        }

        public async Task<Wallet> GetWalletByAccountIDAndType(int accountID, int type)
        {
            var wallet = await _context.Wallets.Include(w => w.WalletType)
                .Where(w => w.Status == 1 && w.AccountId == accountID && w.WalletTypeId == type).FirstOrDefaultAsync();
            return wallet;
        }

        public async Task<Wallet> GetWalletByID(Guid walletId)
        {
            var wallet = await _context.Wallets.Include(w => w.WalletType)
                .Where(w => w.WalletId == walletId).FirstOrDefaultAsync();
            return wallet;
        }

        public async Task<Wallet> UpdateWallet(Wallet wallet)
        {
            var walletFound = await _context.Wallets.Where(w => w.WalletId == wallet.WalletId).FirstOrDefaultAsync();
            if (wallet == null) return null;
            walletFound.Balance = wallet.Balance;
            _context.Wallets.Update(walletFound);
            await _context.SaveChangesAsync();
            return wallet;
        }
    }
}
