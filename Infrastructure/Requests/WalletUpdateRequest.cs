using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Requests
{
    public class WalletUpdateRequest
    {
        public Guid WalletId { get; set; }
        public int Balance { get; set; }
    }
}
