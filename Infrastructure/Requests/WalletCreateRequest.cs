using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Requests
{
    public class WalletCreateRequest
    {
        public WalletTypeEnum WalletType { get; set; }
    }
}
