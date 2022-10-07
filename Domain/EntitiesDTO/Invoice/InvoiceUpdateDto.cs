using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class InvoiceUpdateDto
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public int ContractId { get; set; }
        public int SenderId { get; set; }

        public virtual ICollection<InvoiceHistoryUpdateDto>? InvoiceHistories { get; set; }
    }
}
