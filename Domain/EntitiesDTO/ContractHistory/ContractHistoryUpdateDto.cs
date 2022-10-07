using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ContractHistoryUpdateDto
    {
        public int ContractHistoryId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ContractHistoryStatus { get; set; }
        public DateTime ContractExpiredDate { get; set; }
        public int ContractId { get; set; } // Contract
    }
}
