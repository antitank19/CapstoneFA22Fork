using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class ContractHistoryCreateDto
    {
        public int UserId { get; set; } // User Id
        public DateTime DateSigned { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ContractStatus { get; set; }
        public int FlatId { get; set; }
        public Flat Flat { get; set; }
        public virtual ICollection<InvoiceCreateDto> Invoices { get; set; }
        public virtual ICollection<ContractHistoryCreateDto> ContractHistories { get; set; }
    }
}
