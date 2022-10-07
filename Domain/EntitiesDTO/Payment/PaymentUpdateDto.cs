using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class PaymentUpdateDto
    {
        public int PaymentId { get; set; }
        public string Detail { get; set; }
        public float Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentTime { get; set; }
        public TimeSpan PaymentPeriod { get; set; }
        public DateTime CreatedTime { get; set; }
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
