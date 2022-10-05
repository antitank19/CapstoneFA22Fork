using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class PaymentTypeGetDto
    {
        public int PaymentTypeId { get; set; }
        public string PaymentName { get; set; }
        public string PaymentStatus { get; set; }
        public virtual ICollection<PaymentGetDto> Payments { get; set; }

    }
}
