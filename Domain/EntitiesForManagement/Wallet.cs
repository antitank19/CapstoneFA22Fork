using System;
using System.Collections.Generic;

namespace Domain.EntitiesForManagement
{
    public class Wallet
    {
        public Guid WalletId { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AccountId { get; set; }
        public int WalletTypeId { get; set; }
        public int Status { get; set; }
        public virtual WalletType WalletType { get; set; } = null!;
    }
}
